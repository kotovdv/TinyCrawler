using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "TinyCrawler/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private AnimatorController animatorController;
}