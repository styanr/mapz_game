using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    private SerializedProperty _enemyFactoriesProperty;
    private SerializedProperty _spawnDelayProperty;
    private SerializedProperty _enemySpawnChancesProperty;

    private void OnEnable()
    {
        _enemyFactoriesProperty = serializedObject.FindProperty("_enemyFactories");
        _spawnDelayProperty = serializedObject.FindProperty("_spawnDelay");
        _enemySpawnChancesProperty = serializedObject.FindProperty("_enemySpawnChances");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_enemyFactoriesProperty, true);
        EditorGUILayout.PropertyField(_spawnDelayProperty);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Spawn Chances");

        EditorGUI.indentLevel++;
        int arraySize = _enemySpawnChancesProperty.arraySize;
        arraySize = EditorGUILayout.DelayedIntField("Size", arraySize);

        if (arraySize != _enemySpawnChancesProperty.arraySize)
        {
            while (arraySize < _enemySpawnChancesProperty.arraySize)
            {
                _enemySpawnChancesProperty.DeleteArrayElementAtIndex(_enemySpawnChancesProperty.arraySize - 1);
            }

            while (arraySize > _enemySpawnChancesProperty.arraySize)
            {
                _enemySpawnChancesProperty.InsertArrayElementAtIndex(_enemySpawnChancesProperty.arraySize);
            }
        }

        for (int i = 0; i < _enemySpawnChancesProperty.arraySize; i++)
        {
            SerializedProperty spawnChanceProperty = _enemySpawnChancesProperty.GetArrayElementAtIndex(i);

            SerializedProperty enemyTypeProperty = spawnChanceProperty.FindPropertyRelative("EnemyType");
            SerializedProperty spawnChanceValueProperty = spawnChanceProperty.FindPropertyRelative("SpawnChance");

            EditorGUILayout.PropertyField(enemyTypeProperty);
            EditorGUILayout.PropertyField(spawnChanceValueProperty);

            EditorGUILayout.Space();
        }

        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
