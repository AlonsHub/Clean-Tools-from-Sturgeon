﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor 
{
    void CalculateActionVariations();
    List<ActionVariation> GetActionVariations(); //maybe limit access to this, we must have a listalways needed 

    void PerformAction();
}
