using System;
using System.Collections;
using UnityEngine;

public static class ResourceLoader
{
  private static readonly Hashtable loadedResources = new Hashtable();

  public static T LoadResource<T>(string resourceName) where T : UnityEngine.Object
  {
    if (loadedResources.ContainsKey(resourceName))
    {
      return (T)loadedResources[resourceName];
    }
    else
    {
      T resource = Resources.Load<T>(resourceName);
      if (resource != null)
      {
        loadedResources.Add(resourceName, resource);
        return resource;
      }
      else
      {
        Debug.LogWarning("Resource not found: " + resourceName);
        return null;
      }
    }
  }
}