using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

  private Quest _currentQuest;
  private List<Quest> _completedQuests;
  private List<Quest> _failedQuests;
  private List<Quest> _currentQuestOptions;
  private int _currentMaxQuestOptions = 2;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public Quest GetCurrentQuest()
  {
    return _currentQuest;
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

  }

  public void RegenerateQuestOptions()
  {
    ClearQuestOptions();
    for (int i = 0; i < _currentMaxQuestOptions; i++)
    {

    }
  }

  public void AddQuestOption(Quest.Difficulty difficulty)
  {
    _currentQuestOptions.Add(new Quest(difficulty));
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
