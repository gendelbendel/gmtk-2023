using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

  private Quest _currentQuest;
  private List<Quest> _completedQuests;
  private List<Quest> _failedQuests;
  public List<Quest> _currentQuestOptions;
  private int _currentMaxQuestOptions;
  private int _absoluteMaxQuestOptions;
  private int _highlightedQuestIndex;
  private bool _hasConfirmedQuest;

  [SerializeField]
  public GameObject questDetailsScreen;

  // Start is called before the first frame update
  void Start()
  {
    _currentQuest = null;
    _completedQuests = new List<Quest>();
    _failedQuests = new List<Quest>();
    _currentQuestOptions = new List<Quest>();

    _currentMaxQuestOptions = 2;
    _absoluteMaxQuestOptions = 4;
    _highlightedQuestIndex = -1;
    // _hasConfirmedQuest = false;
    RegenerateQuestOptions();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetMaxQuestQuantity(int qty)
  {
    if (qty > _absoluteMaxQuestOptions)
    {
      _currentMaxQuestOptions = _absoluteMaxQuestOptions;
      return;
    }
    if (qty < 1)
    {
      _currentMaxQuestOptions = 1;
      return;
    }
    _currentMaxQuestOptions = qty;
  }

  public Quest GetCurrentQuest()
  {
    return _currentQuest;
  }

  public List<Quest> GetQuestOptions()
  {
    return _currentQuestOptions;
  }

  public void HighlightQuest(int index)
  {
    _highlightedQuestIndex = index;
    _currentQuest = _currentQuestOptions[index];
    questDetailsScreen.SetActive(true);
    UpdateQuestDetails();
  }

  public void UpdateQuestDetails()
  {
    GameObject.Find("QuestType").GetComponent<TextMeshProUGUI>().text = $"Quest: {_currentQuest.GetThemeName()}";
    GameObject.Find("XPRewardAmount").GetComponent<TextMeshProUGUI>().text = _currentQuest.GetReward().Exp.ToString();
    GameObject.Find("GoldRewardAmount").GetComponent<TextMeshProUGUI>().text = _currentQuest.GetReward().Gold.ToString();
    GameObject.Find("CorruptionRewardAmount").GetComponent<TextMeshProUGUI>().text = _currentQuest.GetReward().Corruption.ToString();
    GameObject.Find("QuestFluff").GetComponent<TextMeshProUGUI>().text = _currentQuest.GetQuestObjectiveText();
    switch (_currentQuest.GetPartySize())
    {
      case 2:
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero1").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero2").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero3").SetActive(false);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero4").SetActive(false);
        break;
      case 3:
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero1").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero2").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero3").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero4").SetActive(false);
        break;
      case 4:
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero1").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero2").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero3").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero4").SetActive(true);
        break;
      default:
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero1").SetActive(true);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero2").SetActive(false);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero3").SetActive(false);
        GameObjectUtils.GetActiveAndInactiveGameobjectByName("Hero4").SetActive(false);
        break;
    }
  }

  public void UpdateQuestOption(int index)
  {
    GameObject questOption = GameObjectUtils.GetActiveAndInactiveGameobjectByName($"Quest{index + 1}");
    questOption.SetActive(true);
    questOption.transform.Find("QuestText/QuestThemeText").GetComponent<TextMeshProUGUI>().text = $"Quest: {_currentQuestOptions[index].GetThemeName()}";
    questOption.transform.Find("QuestText/QuestFluffText").GetComponent<TextMeshProUGUI>().text = _currentQuestOptions[index].GetQuestObjectiveText();
  }

  public void CancelHighlightQuest()
  {
    _highlightedQuestIndex = -1;
    _currentQuest = null;
    questDetailsScreen.SetActive(false);
  }

  public void ConfirmQuest(int index)
  {
    _currentQuest = _currentQuestOptions[index];
    // _hasConfirmedQuest = true;
    ClearQuestOptions();
  }

  public void CompleteCurrentQuest()
  {
    _completedQuests.Add(_currentQuest);
    _currentQuest = null;
  }

  public void FailCurrentQuest()
  {
    _failedQuests.Add(_currentQuest);
    _currentQuest = null;
  }

  public void ClearQuestOptions()
  {
    _currentQuestOptions.Clear();
    for (int i = 0; i < _absoluteMaxQuestOptions; i++)
    {
      ClearQuestOption(i);
    }
  }

  public void ClearQuestOption(int index)
  {
    GameObject questOption = GameObjectUtils.GetActiveAndInactiveGameobjectByName($"Quest{index + 1}");
    questOption.SetActive(false);
  }

  public void RegenerateQuestOptions()
  {
    ClearQuestOptions();
    // _hasConfirmedQuest = false;
    _currentQuest = null;
    for (int i = 0; i < _currentMaxQuestOptions; i++)
    {
      AddQuestOption((Quest.Difficulty)i, Quest.GetRandomTheme());
      UpdateQuestOption(i);
    }
  }

  public void AddQuestOption(Quest.Difficulty difficulty, Quest.Theme theme)
  {
    _currentQuestOptions.Add(GenerateQuest(difficulty, theme));
  }

  public Quest GenerateQuest(Quest.Difficulty difficulty)
  {
    return new Quest(difficulty);
  }

  public Quest GenerateQuest(Quest.Difficulty difficulty, Quest.Theme theme)
  {
    return new Quest(difficulty, theme);
  }
}
