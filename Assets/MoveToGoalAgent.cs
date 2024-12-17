using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class MoveToGoalAgent : Agent
{
[SerializeField] private Transform targetTransform;
[SerializeField] private Transform handTransform;
[SerializeField] private Transform middlepointTransform;
[SerializeField] private Material winMaterial;
//[SerializeField] private Material loseMaterial;
[SerializeField] private MeshRenderer floorMeshRenderer;

float move1;
float move2;
float move3;


    public float reductionAmount = 0.01f;
    // En küçük boyut
    public float minScale = 0.5f;

   // public int maxSteps = 1000; // Maksimum adım sayısı
   // private int currentStep = 0; // Şu anki adım sayısı

//public GameObject objectToSpawn;

//    void Start(){
//      Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));

        // Oluşturulacak nesneyi rastgele konumda ve rotasyonla oluştur
//        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
//    }
// Vector3(Random.Range(2f, 3f), Random.Range(2.5f, 3.5f), Random.Range(-1.5f, 1.5f));
    public override void OnEpisodeBegin()
    {
      //  base.OnEpisodeBegin();
    //  transform.localPosition = Vector3.zero;
    //başlarken kaldığı yerden devam etsin robot
    /*move1 = 0;
    move2 = 0;
    move3 = 0;
    PlayerPrefs.SetFloat("move1", 0);
    PlayerPrefs.SetFloat("move2", 0);
    PlayerPrefs.SetFloat("move3", 0);*/
    targetTransform.localPosition = new Vector3(Random.Range(2.5f, 3.5f), Random.Range(2.5f, 3.5f), Random.Range(-1.5f, 1.5f));
    }
    public override void CollectObservations(VectorSensor sensor)
    {
       // base.CollectObservations(sensor);
        sensor.AddObservation(handTransform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
        sensor.AddObservation(middlepointTransform.localPosition);

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
       // base.OnActionReceived(actions);
       //Debug.Log(actions.ContinuousActions[0]);
        move1 = actions.ContinuousActions[0];
        move2 = actions.ContinuousActions[1];
        move3 = actions.ContinuousActions[2];

       //float moveSpeed = 3f;
       //transform.localPosition += new Vector3(moveX,0,moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //base.Heuristic(actionsOut);
       // ActionSegment<float> continousActions = actionsOut.ContinuousActions;
       // continousActions[0] = Input.GetAxisRaw("Horizontal");
       // continousActions[1] = Input.GetAxisRaw("Vertical");
    }

    public void HandleTriggerEvent(Goal goal){
            if(goal != null){
            SetReward(+1f);
            floorMeshRenderer.material = winMaterial;
            Debug.Log("ulasti");
         Vector3 currentScale = targetTransform.localScale;

        // Yeni ölçeği hesapla
        float newScaleX = Mathf.Max(currentScale.x - reductionAmount, minScale);
        float newScaleY = Mathf.Max(currentScale.y - reductionAmount, minScale);
        float newScaleZ = Mathf.Max(currentScale.z - reductionAmount, minScale);

        // Yeni ölçeği ayarla
        targetTransform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
            EndEpisode();
         }
           // if(other.TryGetComponent<Wall>(out Wall wall)){
         //   SetReward(-1f);
         //   floorMeshRenderer.material = loseMaterial;
         //   EndEpisode();
         //   }
        }

        void Update()
        {
            PlayerPrefs.SetFloat("move1", move1);
            PlayerPrefs.SetFloat("move2", move2);
            PlayerPrefs.SetFloat("move3", move3);
        }

}
