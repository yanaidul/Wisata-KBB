using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script interface yang berperan sebagai script template untuk player data
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IInitializer <T> where T: struct
{
    /// <summary>
    /// To initialize first data
    /// </summary>
    /// <param name="data">First data</param>
    void Init(T data); 
}
