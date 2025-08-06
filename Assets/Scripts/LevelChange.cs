using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchange : MonoBehaviour {
    [SerializeField]
    private LevelConnection _connection;

    [SerializeField]
    private string _targetscene;

    [SerializeField]
    private Transform _spawnpoint;

    private void Start(){
        if( _connection == LevelConnection.ActiveConnection){
            FindObjectOfType<PlayerMovement>().transform.position = _spawnpoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerMovement>();
        if ( player != null){

            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetscene);

        }
        
    }
}