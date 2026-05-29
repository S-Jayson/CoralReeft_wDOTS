using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

// =============================================================================
// VATComponents.cs
// 
// These components bridge ECS data to the VAT shader via DOTS Instancing.
// Entities Graphics automatically uploads [MaterialProperty] components
// to the GPU as per-instance shader properties — no manual system needed.
//
// Place at: Assets/Scripts/DCR2/VATComponents.cs
// =============================================================================

namespace DCR2
{
    // -------------------------------------------------------------------------
    // Per-entity phase offset → shader property "_PhaseOffset"
    //
    // The [MaterialProperty] attribute tells Entities Graphics:
    //   "Every entity with this component gets its own value for _PhaseOffset
    //    uploaded to the GPU, overriding the material's default."
    //
    // The shader reference name "_PhaseOffset" MUST match exactly:
    //   - The Properties block name in the shader
    //   - The CBUFFER entry name
    //   - The DOTS_INSTANCED_PROP name
    //
    // The struct field MUST be named "Value" and match the shader type size.
    //   float in shader = float in struct (4 bytes)
    // -------------------------------------------------------------------------
    [MaterialProperty("_PhaseOffset")]
    public struct VATPhaseOffset : IComponentData
    {
        public float Value;
    }

    // -------------------------------------------------------------------------
    // Per-entity playback speed → shader property "_Speed"
    //
    // This allows each fish to play its swim animation at a different rate.
    // Combined with PhaseOffset, prevents the "robot army" synchronized look.
    //
    // Optional: You could also drive this from fish.currentSpeed in a system
    // so fish that are swimming faster also animate faster.
    // -------------------------------------------------------------------------
    [MaterialProperty("_Speed")]
    public struct VATPlaybackSpeed : IComponentData
    {
        public float Value;
    }
}
