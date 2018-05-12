using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalSystem : MonoBehaviour
{

    // This object represents the ship's electrical system
    // It allows the ship's electric appliances such as lights to react to various events
    // I initially thought it to be only for visive feedback, but it could technically be used for gameplay elements too since ElectricAppliance is an interface

    public enum ElectricalSystemState
    {
        Nominal,
        IncreasedProduction,
        DangerousIncreasedProduction,
        IncreasedConsumption,
        Offline
    }

    private List<ElectricalAppliance> electricalAppliances;
    private ElectricalSystemState currentElectricalSystemState;

    //tweak this through the Unity editor
    public float applianceBreakInterval = 10f;

    float timer;

    void Start()
    {
        electricalAppliances = new List<ElectricalAppliance>();
        electricalAppliances.AddRange(FindObjectsOfType<ElectricalAppliance>());
        currentElectricalSystemState = ElectricalSystemState.Nominal;
    }

    // This function breaks a random appliance connected to the system
    // The bool parameter makes it recursive to be sure that one appliance is broken (some may be already broken, or cannot be broken)
    // If I did my math correctly the recursiveness of the function should be more optimized than just looping in a while condition until something breaks
    bool BreakRandomAppliance(bool breakAtLeastOne)
    {
        bool applianceBroke = electricalAppliances[UnityEngine.Random.Range(0, electricalAppliances.Count)].BreakAppliance();
        if (breakAtLeastOne && !applianceBroke)
            return BreakRandomAppliance(true);
        else
            return applianceBroke;
    }

    // A damaging power surge that will break one of the appliances of the ship
    void PowerSurge()
    {
        foreach (ElectricalAppliance appliance in electricalAppliances)
        {
            appliance.Surge();
        }
        BreakRandomAppliance(false);
    }

    // A drastic increase in power production, if flagged to be dangerous an appliance will break every applianceBreakInterval seconds
    void PowerProductionIncreaseStart(bool dangerous)
    {
        foreach (ElectricalAppliance appliance in electricalAppliances)
        {
            appliance.OverchargeStart();
        }

        if (dangerous)
        {
            currentElectricalSystemState = ElectricalSystemState.DangerousIncreasedProduction;
        }
        else
        {
            currentElectricalSystemState = ElectricalSystemState.IncreasedProduction;
        }
    }

    // This function puts all appliances in an Undercharged state
    void PowerConsumptionIncreaseStart()
    {
        foreach (ElectricalAppliance appliance in electricalAppliances)
        {
            appliance.UnderchargeStart();
        }
        currentElectricalSystemState = ElectricalSystemState.IncreasedConsumption;
    }

    // This function ends the Overcharged state for all appliances
    void PowerProductionIncreaseEnd()
    {
        foreach (ElectricalAppliance appliance in electricalAppliances)
        {
            appliance.OverchargeEnd();
        }
        currentElectricalSystemState = ElectricalSystemState.Nominal;
    }

    //This function ends the Undercharge state for all appliances
    void PowerConsumptionIncreaseEnd()
    {
        foreach (ElectricalAppliance appliance in electricalAppliances)
        {
            appliance.UnderchargeEnd();
        }
        currentElectricalSystemState = ElectricalSystemState.Nominal;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > applianceBreakInterval && currentElectricalSystemState == ElectricalSystemState.DangerousIncreasedProduction)
        {
            BreakRandomAppliance(true);
            timer = 0f;
        }
    }

}
    
