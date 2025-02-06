using Enums;
using UnityEngine;

namespace ItemsContent
{
   public class Resource : MonoBehaviour
   {
      [field:SerializeField] public ResourceType Type { get; protected set; }
   }
}