using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Characters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
  private List<Hero> _heroes = new List<Hero>();
  private const int _maxHeroRecruited = 6;

  public Dictionary<HeroClassName, System.Type> heroTypeMapping = new Dictionary<HeroClassName, System.Type> {
    {HeroClassName.Barbarian, typeof(Barbarian)},
    {HeroClassName.Rogue, typeof(Rogue)},
    {HeroClassName.Cleric, typeof(Cleric)},
    {HeroClassName.Knight, typeof(Knight)},
    {HeroClassName.Blacksmith, typeof(Blacksmith)},
    {HeroClassName.Wizard, typeof(Wizard)},
    {HeroClassName.Ranger, typeof(Ranger)},
  };

  [SerializeField] public GameObject heroRowPrefab;
  private GameObject _heroBarObject;

  private bool _heroesChanged = false;

  // Start is called before the first frame update
  void Start()
  {
    _heroBarObject = GameObject.Find("HeroBar");
    AddRandomHeroes();
    UpdateHeroesUI();
  }

  // Update is called once per frame
  void Update()
  {
    if (_heroesChanged)
    {
      UpdateHeroesUI();
      _heroesChanged = false;
    }
  }

  public void UpdateHeroesUI()
  {
    // Update all rows in the Heroes List UI
    ClearHeroesUI();
    for (int i = 0; i < _heroes.Count; i++)
    {
      GameObject row = Instantiate(heroRowPrefab, _heroBarObject.transform);
      // StartCoroutine(DelayedAccessChildObjects(row, i));
      row.name = $"HeroUI{i}";
      row.transform.Find("HeroContainer/HeroImage").GetComponent<Image>().sprite = _heroes[i].CharacterSprite;
      row.transform.Find("HeroContainer/ClassNameInfoContainer/ClassNameContainer/ClassImage").GetComponent<Image>().sprite = _heroes[i].ClassIconSprite;
      row.transform.Find("HeroContainer/ClassNameInfoContainer/ClassNameContainer/NameText").GetComponent<TextMeshProUGUI>().text = _heroes[i].Name;
      row.transform.Find("HeroContainer/ClassNameInfoContainer/LvlGoldXPContainer/LvlText").GetComponent<TextMeshProUGUI>().text = _heroes[i].Level.ToString();
      row.transform.Find("HeroContainer/ClassNameInfoContainer/LvlGoldXPContainer/GoldText").GetComponent<TextMeshProUGUI>().text = _heroes[i].GoldInventory.ToString();
      row.transform.Find("HeroContainer/ClassNameInfoContainer/LvlGoldXPContainer/XPText").GetComponent<TextMeshProUGUI>().text = _heroes[i].XP.ToString();
    }
  }

  public void UpdateHeroUI(int index)
  {
    // Update row of hero in UI
  }

  public void AddRandomHeroes()
  {
    // var types = Assembly.GetExecutingAssembly().GetTypes();
    // var availableHeroTypes = types.Where(t => t.IsSubclassOf(typeof(Hero)));
    for (int i = 0; i < _maxHeroRecruited; i++)
    {
      _heroes.Add(GetRandomHero());
    }
    Debug.Log(_heroes.Count);
    _heroesChanged = true;
  }

  public void RerollHeroes()
  {
    ClearHeroes();
    ClearHeroesUI();
    AddRandomHeroes();
    UpdateHeroesUI();
  }

  public void ClearHeroes()
  {
    _heroes.Clear();
    _heroesChanged = true;
  }

  public void ClearHeroesUI()
  {
    int childCount = _heroBarObject.transform.childCount;
    for (int i = childCount - 1; i >= 0; i--)
    {
      Destroy(_heroBarObject.transform.GetChild(i).gameObject);
    }
  }

  public Hero GetRandomHero()
  {
    HeroClassName selectedHero = GetRandomHeroClassName();
    heroTypeMapping.TryGetValue(selectedHero, out Type heroClassType);
    return InstantiateHero(heroClassType);
  }

  public Hero InstantiateHero(System.Type type)
  {
    ConstructorInfo[] constructors = type.GetTypeInfo().DeclaredConstructors.ToArray();
    ConstructorInfo defaultConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 1 && c.GetParameters()[0].HasDefaultValue);//Array.Find(constructors, c => c.GetParameters().Length == 0);
    object instance = defaultConstructor.Invoke(new object[] { Type.Missing });
    return (Hero)instance;
  }

  public static HeroClassName GetRandomHeroClassName()
  {
    return (HeroClassName)DiceRoller.Roll(0, Enum.GetValues(typeof(HeroClassName)).Length);
  }
}
