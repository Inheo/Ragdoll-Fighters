using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface IStartCoroutine
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}