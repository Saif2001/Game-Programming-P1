using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract States RunCurrentState();       //abstract class for other states to inherit from



}
