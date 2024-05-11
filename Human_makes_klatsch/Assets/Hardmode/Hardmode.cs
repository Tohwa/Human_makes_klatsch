using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hardmode : MonoBehaviour
{
    private bool moreSpeed { get; set; }
    private bool lessSpeed { get; set; }
    private bool noNests { get; set; }
    private bool halfHealth { get; set; }

    private bool doubleHealth { get; set; }

    public bool GetMoreSpeed(){ return moreSpeed; }

    public void SetMoreSpeed(bool _value) { moreSpeed = _value; }

    public bool GetLessSpeed() { return lessSpeed; }
    
    public void SetLessSpeed(bool _value) { lessSpeed = _value; }

    public bool GetNoNests() { return noNests; }
    
    public void SetNoNests(bool _value) {  noNests = _value; }
    
    public bool GetHalfHealth() { return halfHealth; }

    public void SetHalfHearts(bool _value) { halfHealth = _value; }

    public bool GetDoubleHealth() { return doubleHealth; }

    public void SetDoubleHealth(bool _value) { doubleHealth = _value; }
}
