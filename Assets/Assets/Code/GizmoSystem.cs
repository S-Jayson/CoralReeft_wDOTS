using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace DCR2
{
    [RequireMatchingQueriesForUpdate]
    public partial struct GizmoSystem : ISystem
    {
        //Trying to make it work with just 1 school
        //EntityQuery query;

        public void OnUpdate(ref SystemState state)
        {
            // var world = state.WorldUnmanaged;
            // var fishQuery = SystemAPI.QueryBuilder().WithAll<DynamicSchool>().Build();
            // var centroidQuery1 = SystemAPI.QueryBuilder().WithAll<centroidGizmo>().Build(); // Query with los gizmos 
            // NativeArray<Entity> entityArray = fishQuery.ToEntityArray(Allocator.TempJob);

            // // check that each gizmo is following a fish of a different school
            // int centroidCount = centroidQuery1.CalculateEntityCount();
            // NativeArray<Entity> uniqueFishID = CollectionHelper.CreateNativeArray<Entity, RewindableAllocator>(centroidCount, ref world.UpdateAllocator);
            // state.EntityManager.GetAllUniqueSharedComponents(out NativeList<SemiStaticSchool> uniqueFishComponents, world.UpdateAllocator.ToAllocator);
            // int id = 0;
            // int i = 0;
            // foreach (var fishSettings in uniqueFishComponents)
            // {
            //     int schoolID = fishSettings.schoolID;
                
            //     if (id == schoolID)
            //     {
            //         uniqueFishID[id] = entityArray[i];
            //         id++;
            //         if (id == centroidCount) break;
            //     }
            //     i++;
            // }

            // //var centroidVal = state.EntityManager.GetComponentData<DynamicSchool>(entityArray[0]).centroid;

            // var localToWorldLookup = SystemAPI.GetComponentLookup<LocalToWorld>();
            // //I think this could be done in the SchoolSpawner (instantiating the centroids)
            // //Array to store the amount of gizmos
            // //TODO :: Right now it only stores 1 entity, it should store the same amount as the amount of schoolSpawners

            // //Instantiate the sphere prefab and put it in the centroidGizmoArray
            // //state.EntityManager.Instantiate(centerGizmo.ValueRO.spherePrefab);
            // //Debug.Log("In Onpudate");
            // var centroidQuery = SystemAPI.QueryBuilder().WithAll<centroidGizmoComponent>().WithAll<LocalToWorld>().Build();
            // NativeArray<Entity> centroidEntityArray = centroidQuery.ToEntityArray(Allocator.TempJob);

            // //?? its spawning the entity but I cant see it???
            // //Debug.Log(centroidQuery.CalculateEntityCount());
            // // var localToWorldx = new LocalToWorld
            // //         {
            // //             Value = float4x4.TRS(new float3(0f,0f,0f), quaternion.LookRotationSafe(new float3(0f,0f,0f), math.up()), new float3(1.0f, 1.0f, 1.0f))
            // //         };
            // // localToWorldLookup[centroidEntityArray[0]] = localToWorldx;

            
            // //Debug.Log(localToWorldLookup[centroidEntityArray[0]]);
            // foreach (var (centerGizmo, entity) in
            //          SystemAPI.Query<RefRW<centroidGizmo>>()
            //              .WithEntityAccess())
            //     {
            //         Debug.Log("SettingLocation");
            //         var localToWorld = new LocalToWorld
            //         {
            //             Value = float4x4.TRS(new float3(0f,0f,0f), quaternion.LookRotationSafe(new float3(0f,0f,0f), math.up()), new float3(1.0f, 1.0f, 1.0f))
            //         };
            //         localToWorldLookup[entity] = localToWorld;
            //     }


            // // define the new centroid position
            
        }
    }
}
