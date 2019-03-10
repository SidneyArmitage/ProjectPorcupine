using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

[MoonSharpUserData]
public class GearManager : IEnumerable<Gear> {

    private List<Gear> gears;

    public GearManager()
    {
        gears = new List<Gear>();
    }

    public IEnumerator<Gear> GetEnumerator()
    {
        return gears.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return gears.GetEnumerator();
    }
}
