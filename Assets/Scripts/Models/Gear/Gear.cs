#region License
// ====================================================
// Project Porcupine Copyright(C) 2016 Team Porcupine
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using MoonSharp.Interpreter;
using System;
using ProjectPorcupine.Entities;

[MoonSharpUserData]
public class Gear : IPrototypable
{
    /// Stats, to be transferred to the character.
    public Dictionary<string, Stat> Stats { get; protected set; }

    /// <summary>
    /// Slots which can be used to attach onto.
    /// </summary>
    public Dictionary<string, bool> Slots { get; protected set; }

    public string Slot { get; protected set; }

    /// <summary>
    /// Gets the code used for Gear of the furniture.
    /// </summary>
    public string LocalizationName { get; private set; }

    /// <summary>
    /// Gets the description of the Gear. This is used by localization.
    /// </summary>
    public string LocalizationDescription { get; private set; }

    /// <summary>
    /// Gets the string that defines the type of object the Equipment is.
    /// </summary>
    /// <value>The type of the Equipment.</value>
    public string Type { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Furniture"/> class.
    /// This constructor is used to create prototypes and should never be used ouside the Prototype Manager.
    /// </summary>
    public Gear()
    {

    }

    /// <summary>
    /// Copy Constructor -- don't call this directly, unless we never
    /// do ANY sub-classing. Instead use Clone(), which is more virtual.
    /// </summary>
    private Gear(Gear other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reads the prototype from the specified JObject.
    /// </summary>
    /// <param name="jsonProto">The JProperty containing the prototype.</param>
    public void ReadJsonPrototype(JProperty jsonProto)
    {
        Type = jsonProto.Name;
        JToken innerJson = jsonProto.Value;
        Slot = PrototypeReader.ReadJson(Slot, innerJson["Slot"]);
        LocalizationName = PrototypeReader.ReadJson("gear_" + Type, innerJson["LocalizationName"]);
        LocalizationDescription = PrototypeReader.ReadJson("gear_" + Type + "_desc", innerJson["LocalizationDescription"]);
        if(innerJson["Stats"] != null)
        {
            foreach(JToken stat in innerJson["Stats"])
            {
                
                Stat prototypeStat = PrototypeManager.Stat.Get(((JProperty)stat).Name);
                Stat newStat = prototypeStat.Clone();
                int value = 0;
                value = PrototypeReader.ReadJson(value, stat);
                newStat.Value = value;
                Stats.Add(((JProperty)stat).Name, newStat);
            }
        }
        if(innerJson["Slots"] != null)
        {
            string[] slots = new string[0];
            slots = PrototypeReader.ReadJson(slots, innerJson["Slots"]);
            foreach (string slot in slots)
            {
                Slots.Add(slot, false);
            }
        }
    }
}
