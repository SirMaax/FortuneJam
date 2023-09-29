using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    [SerializeField]private List<MonoBehaviour> referenceList;
    [SerializeField]private List<GameObject> referenceListObject;
    [SerializeField] private Dictionary<Enums.RefEnum, MonoBehaviour> dictionary;
    [SerializeField] private Dictionary<Enums.RefEnumGame, GameObject> dictionaryObject;
    public static ReferenceManager referenceManager;
    
   
    // Start is called before the first frame update

    private void Awake()
    {
        referenceManager = this;
        
        dictionary = new Dictionary<Enums.RefEnum, MonoBehaviour>();
        dictionary.Add(0,referenceList[0]);
        dictionary.Add(Enums.RefEnum.playerControl,referenceList[1]);
        
        dictionaryObject = new Dictionary<Enums.RefEnumGame, GameObject>();
        dictionaryObject.Add(0,referenceListObject[0]);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MonoBehaviour GiveRef(Enums.RefEnum reference)
    {
        if (dictionary.ContainsKey(reference)) return dictionary[reference];
        return null;
          
    }
    
    public GameObject GiveGame(Enums.RefEnumGame reference)
    {
        if (dictionaryObject.ContainsKey(reference)) return dictionaryObject[reference];
        return null;
          
    }
}
