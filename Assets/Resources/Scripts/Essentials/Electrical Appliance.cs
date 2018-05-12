using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalAppliance : MonoBehaviour {

    public virtual void Surge(){ }
    public virtual void OverchargeStart() { }
    public virtual void OverchargeEnd() { }
    public virtual void UnderchargeStart() { }
    public virtual void UnderchargeEnd() { }
    public virtual bool BreakAppliance() { return false; }

}
