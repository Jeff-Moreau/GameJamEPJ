using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameVariables gameVariables;
    [SerializeField] private TextMeshProUGUI goodDecisions;
    [SerializeField] private TextMeshProUGUI badDecisions;
    // Start is called before the first frame update
    void Start()
    {
        goodDecisions.text = "" + gameVariables.goodDecision;
        badDecisions.text = "" + gameVariables.badDecision;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
