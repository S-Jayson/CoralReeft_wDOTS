using System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;


// =============================================================================
// Changes:
//   1. Added VAT animation fields phaseOffset range, playback speed range
//   2. Baker now also adds VATPhaseOffset and VATPlaybackSpeed components
//   3. Phase and speed are randomized per-entity at spawn time. Randomization
//      happens in the spawn systems. Here we just set defaults.
// TODO:: 1. Make the schoolID generation automatic when creating a new school
//        2. Actually implement the VAT animation in the shader and the system
// =============================================================================


namespace DCR2
{
    public class FishAuthoring : MonoBehaviour
    {
        [Header("School caracteristics")]
        //For now, get the schoolID manually
        //TODO :: Make a unique ID for each school when its created
        public int schoolID;

        [Header("Species Characteristics")]
        public float normalSpeed;
        public float acceleration;
        public float rotationSpeed;

        [Header("Direction Weights")]
        public float couzinDirectionWeight;
        public float centroidFollowingDirectionWeight;

        [Header("Cohesion, seperation and alignment variables")]
        public int minCentroidDistance;
        public int maxCentroidDistance;
        public float alpha;
        public float rho;

        [Header("VAT Animation Defaults")]
        public float vatPlaybackSpeed = 1.0f;

        class Baker : Baker<FishAuthoring>
        {
            // Function to bake the entity that contains the BoidSchool component
            // authoring :: This is the value that has the inputs that the user gave 
            public override void Bake(FishAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                //Adds the SemiStaticSchool component to this entity
                AddSharedComponent(entity, new SemiStaticSchool
                {
                    schoolID = authoring.schoolID,
                    couzinDirectionWeight = authoring.couzinDirectionWeight,
                    centroidFollowingDirectionWeight = authoring.centroidFollowingDirectionWeight,
                    minCentroidDistance = authoring.minCentroidDistance,
                    maxCentroidDistance = authoring.maxCentroidDistance,
                    alpha = authoring.alpha,
                    rho = authoring.rho,
                    acceleration = authoring.acceleration,
                    normalSpeed = authoring.normalSpeed,
                    rotationSpeed = authoring.rotationSpeed,
                });

                //Adds the DynamicSchool component to this entity
                AddComponent(entity, new DynamicSchool
                {
                    centroid = authoring.transform.position
                });

                //Adds the Fish component to this entity
                AddComponent(entity, new Fish{
                    currentSpeed = authoring.normalSpeed
                });

                AddComponent(entity, new VATPhaseOffset
                {
                    Value = 0f
                });

                AddComponent(entity, new VATPlaybackSpeed
                {
                    Value = authoring.vatPlaybackSpeed
                });
            }
        }
    }

    
    //Define each of the components that apply to the fish
    //semiStaticSchool :: Store class caracteristics that don't change often during run time
    //  The reason for that is because for ISharedComponentData its not advised to put values that will change often
    //  that is because it will affect the location where each fish of that class is going to be stored, which will take time processing, and if its done ofthen then that time will stack up
    //
    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    public struct SemiStaticSchool : ISharedComponentData
    {
        public int schoolID;
        public float couzinDirectionWeight;
        public float centroidFollowingDirectionWeight;
        public int minCentroidDistance;
        public int maxCentroidDistance;
        public float alpha;
        public float rho;
        public float acceleration;
        public float normalSpeed;
        public float rotationSpeed;
    }

    // Component that stores dynamic school data, things that are going to be changed constantly
    // IComponentData vr. ISharedComponentData :: As opposed to ISharedComponents, IComponents are designed to be used for an individual entity, and is good to use for vraibles that change often
    //  The centroid is something that is shared with the whole school but it changes constantly, that is why its an IComponents instead of  a ISharedComponent 
    public struct DynamicSchool : IComponentData
    {
        public Vector3 centroid;

    }

    //Stores data that each fish uses and changes individually
    public struct Fish : IComponentData
    {
        public float currentSpeed;
        public bool goToCentroid;
    }
}