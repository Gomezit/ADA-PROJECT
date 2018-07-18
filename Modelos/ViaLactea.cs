﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ViaLactea  {

    public int id;
    public string nombre;

	[NonSerialized]
	public int totalNebulosas;
    public List<Nebulosa> Nebulosas;
}
