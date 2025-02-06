using Enums;
using UnityEngine;

namespace Interfaces
{
    public interface IResourceFactory 
    {
        GameObject  CreateResource(Resource resource);
    }
}