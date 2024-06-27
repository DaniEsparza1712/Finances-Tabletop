using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(TokenManager), typeof(CoinManager), 
    typeof(PlayerPosManager))]
[RequireComponent(typeof(PlayerUIManager))]
public class PlayerManager : MonoBehaviour
{
    private int _currentPos;
    private TokenManager _tokenManager; 
    private CoinManager _coinManager;
    [SerializeField]
    private BoardManager board;
    private PlayerPosManager _playerPosManager;
    private PlayerUIManager _uiManager;

    private List<Activities> turnActivities = new List<Activities>();
    public Transform lookAt;

    public enum Activities
    {
        DrawRedCard,
        DrawGreenCard,
        DrawBlueCard,
        DrawYellowCard,
        DiceThrow
    }

    public bool CanAddCardOption(Card.Option cardOption)
    {
        if (_tokenManager.GetActivos + cardOption.activos < 0)
            return false;
        if (_tokenManager.GetPasivos + cardOption.pasivos < 0)
            return false;
        if (_coinManager.GetBills + cardOption.bills < 0)
            return false;
        if (_coinManager.GetFelicicoins + cardOption.feliciCoins < 0)
            return false;
        if (_coinManager.GetSharecoins + cardOption.shareCoins < 0)
            return false;
        return true;
    }

    public void AddCoins(int bills, int feliciCoins, int shareCoins)
    {
        _coinManager.AddBills(bills);
        _coinManager.AddFelicicoins(feliciCoins);
        _coinManager.AddSharecoins(shareCoins);
        UpdateCoinsUI();
    }

    public void UpdateCoinsUI()
    {
        _uiManager.billsText.text = "$" + _coinManager.GetBills.ToString("D" + 4);
        _uiManager.feliciCoinsText.text = "$" + _coinManager.GetFelicicoins.ToString("D" + 4);
        _uiManager.shareCoinsText.text = "$" + _coinManager.GetSharecoins.ToString("D" + 4);
    }

    public void AddTokens(int income, int obligations)
    {
        _tokenManager.AddActivos(income);
        _tokenManager.AddPasivos(obligations);
        UpdateTokensUI();
    }

    public void UpdateTokensUI()
    {
        _uiManager.incomeText.text = _tokenManager.GetActivos.ToString("D" + 2);
        _uiManager.obligationsText.text = _tokenManager.GetPasivos.ToString("D" + 2);
    }

    public void TurnActions()
    {
        int diceVal = Random.Range(1, 13);
        GetTurnActivities(GetPassedBoxes(diceVal));
        AdvancePositions(diceVal);
        _playerPosManager.ChangePosState(PlayerPosManager.PosState.Moving);
    }
    
    private void AdvancePositions(int positions)
    {
        
        _currentPos += Mathf.Abs(positions);
        if (_currentPos > board.boardBoxes.Count - 1)
        {
            _currentPos -= (board.boardBoxes.Count);
        }
    }

    private List<Box> GetPassedBoxes(int positionsToAdvance)
    {
        List<Box> boxes = new List<Box>();
        for (var i = 1; i <= positionsToAdvance; i++)
        {
            var index = _currentPos + i;
            if (index <= board.boardBoxes.Count-1)
            {
                Box newBox = board.boardBoxes[index];
                boxes.Add(newBox);
                _playerPosManager.AddWayPoint(newBox.GetComponent<Transform>());
            }
            else
            {
                Box newBox = board.boardBoxes[index - (board.boardBoxes.Count - 1) - 1];
                boxes.Add(newBox);
                _playerPosManager.AddWayPoint(newBox.GetComponent<Transform>());
            }
        }
        return boxes;
    }

    private void GetTurnActivities(List<Box> boxes)
    {
        Box lastBox = boxes[boxes.Count - 1];
        boxes.Remove(boxes[boxes.Count - 1]);
        
        //Get middle boxes (yellow and blue)
        foreach (var box in boxes)
        {
            switch(box.GetBoxType)
            {
                case Box.BoxType.Blue:
                    turnActivities.Add(Activities.DrawBlueCard);
                    break;
                case Box.BoxType.Green:
                    break;
                case Box.BoxType.Red:
                    break;
                case Box.BoxType.Yellow:
                    var hasYellow = false;
                    foreach (var activity in turnActivities)
                    {
                        if (activity == Activities.DrawYellowCard)
                            hasYellow = true;
                    }
                    if(!hasYellow)
                        turnActivities.Add(Activities.DrawYellowCard);
                    break;
            }
        }
        
        //Get last box
        switch (lastBox.GetBoxType)
        {
            case Box.BoxType.Blue:
                turnActivities.Add(Activities.DrawBlueCard);
                break;
            case Box.BoxType.Green:
                turnActivities.Add(Activities.DrawGreenCard);
                break;
            case Box.BoxType.Red:
                turnActivities.Add(Activities.DrawRedCard);
                break;
            case Box.BoxType.Yellow:
                var hasYellow = false;
                foreach (var box in boxes)
                {
                    if (box.GetBoxType == Box.BoxType.Yellow)
                        hasYellow = true;
                }
                if(!hasYellow)
                    turnActivities.Add(Activities.DrawYellowCard);
                break;
        }
    }

    public void ExecuteNextAction()
    {
        if (turnActivities.Count > 0)
        {
            BoxAction(turnActivities[0]);
            turnActivities.Remove(turnActivities[0]);
        }
        else
        {
            turnActivities.Add(Activities.DiceThrow);
            ExecuteNextAction();
        }
    }

    private void BoxAction(Activities activity)
    {
        switch (activity)
        {
            case Activities.DrawBlueCard:
                _uiManager.ChangeBlueActive(true);
                break;
            case Activities.DrawGreenCard:
                _uiManager.ChangeGreenActive(true);
                break;
            case Activities.DrawRedCard:
                _uiManager.ChangeRedActive(true);
                break;
            case Activities.DrawYellowCard:
                _uiManager.ChangeYellowActive(true);
                break;
            case Activities.DiceThrow:
                _uiManager.ChangeDiceActive(true);
                break;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _currentPos = 0;
        _playerPosManager = GetComponent<PlayerPosManager>();
        _coinManager = GetComponent<CoinManager>();
        _tokenManager = GetComponent<TokenManager>();
        _uiManager = GetComponent<PlayerUIManager>();
        UpdateCoinsUI();
        UpdateTokensUI();
        ExecuteNextAction();
    }

    private void Update()
    {
        transform.forward = (lookAt.position - transform.position).normalized;
    }
}
