Shader "Unlit/HologramSprite"
{
    Properties
    {
        [NoScaleOffset]_NoizeTexure("NoizeTexure", 2D) = "white" {}
        _AnimSpeed("AnimSpeed", Float) = 0.04
        _Tiling("Tiling", Vector) = (1, 1, 0, 0)
        [NoScaleOffset]_MainTex("MainTex", 2D) = "white" {}
        _Color("Color", Color) = (1, 0, 0, 0)
        [HideInInspector]_QueueOffset("_QueueOffset", Float) = 0
        [HideInInspector]_QueueControl("_QueueControl", Float) = -1
        [HideInInspector][NoScaleOffset]unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "UniversalMaterialType" = "Unlit"
            "Queue"="Transparent"
            "DisableBatching"="False"
            "ShaderGraphShader"="true"
            "ShaderGraphTargetId"="UniversalUnlitSubTarget"
        }
        Pass
        {
            Name "Universal Forward"
        
        // Render State
        Cull Back
        Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
        ZTest LEqual
        ZWrite Off
        
        // Debug
        // <None>
        
        // --------------------------------------------------
        // Pass
        
        HLSLPROGRAM
        
        // Pragmas
        #pragma target 2.0
        #pragma multi_compile_instancing
        #pragma multi_compile_fog
        #pragma instancing_options renderinglayer
        #pragma vertex vert
        #pragma fragment frag
        
        // Keywords
        #pragma multi_compile _ LIGHTMAP_ON
        #pragma multi_compile _ DIRLIGHTMAP_COMBINED
        #pragma shader_feature _ _SAMPLE_GI
        #pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
        #pragma multi_compile_fragment _ DEBUG_DISPLAY
        #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
        // GraphKeywords: <None>
        
        // Defines
        
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_POSITION_WS
        #define VARYINGS_NEED_NORMAL_WS
        #define VARYINGS_NEED_TEXCOORD0
        #define VARYINGS_NEED_COLOR
        #define FEATURES_GRAPH_VERTEX
        /* WARNING: $splice Could not find named fragment 'PassInstancing' */
        #define SHADERPASS SHADERPASS_UNLIT
        #define _FOG_FRAGMENT 1
        #define _SURFACE_TYPE_TRANSPARENT 1
        
        
        // custom interpolator pre-include
        /* WARNING: $splice Could not find named fragment 'sgci_CustomInterpolatorPreInclude' */
        
        // Includes
        #include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DOTS.hlsl"
        #include_with_pragmas "Packages/com.unity.render-pipelines.universal/ShaderLibrary/RenderingLayers.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DBuffer.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
        
        // --------------------------------------------------
        // Structs and Packing
        
        // custom interpolators pre packing
        /* WARNING: $splice Could not find named fragment 'CustomInterpolatorPrePacking' */
        
        struct Attributes
        {
             float3 positionOS : POSITION;
             float3 normalOS : NORMAL;
             float4 tangentOS : TANGENT;
             float4 uv0 : TEXCOORD0;
             float4 color : COLOR;
            #if UNITY_ANY_INSTANCING_ENABLED
             uint instanceID : INSTANCEID_SEMANTIC;
            #endif
        };
        struct Varyings
        {
             float4 positionCS : SV_POSITION;
             float3 positionWS;
             float3 normalWS;
             float4 texCoord0;
             float4 color;
            #if UNITY_ANY_INSTANCING_ENABLED
             uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
             uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
             uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
             FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        struct SurfaceDescriptionInputs
        {
             float3 ObjectSpacePosition;
             float4 uv0;
             float4 VertexColor;
             float3 TimeParameters;
        };
        struct VertexDescriptionInputs
        {
             float3 ObjectSpaceNormal;
             float3 ObjectSpaceTangent;
             float3 ObjectSpacePosition;
        };
        struct PackedVaryings
        {
             float4 positionCS : SV_POSITION;
             float4 texCoord0 : INTERP0;
             float4 color : INTERP1;
             float3 positionWS : INTERP2;
             float3 normalWS : INTERP3;
            #if UNITY_ANY_INSTANCING_ENABLED
             uint instanceID : CUSTOM_INSTANCE_ID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
             uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
             uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
             FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
            #endif
        };
        
        PackedVaryings PackVaryings (Varyings input)
        {
            PackedVaryings output;
            ZERO_INITIALIZE(PackedVaryings, output);
            output.positionCS = input.positionCS;
            output.texCoord0.xyzw = input.texCoord0;
            output.color.xyzw = input.color;
            output.positionWS.xyz = input.positionWS;
            output.normalWS.xyz = input.normalWS;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }
        
        Varyings UnpackVaryings (PackedVaryings input)
        {
            Varyings output;
            output.positionCS = input.positionCS;
            output.texCoord0 = input.texCoord0.xyzw;
            output.color = input.color.xyzw;
            output.positionWS = input.positionWS.xyz;
            output.normalWS = input.normalWS.xyz;
            #if UNITY_ANY_INSTANCING_ENABLED
            output.instanceID = input.instanceID;
            #endif
            #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
            output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
            #endif
            #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
            output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
            #endif
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            output.cullFace = input.cullFace;
            #endif
            return output;
        }
        
        
        // --------------------------------------------------
        // Graph
        
        // Graph Properties
        CBUFFER_START(UnityPerMaterial)
        float4 _NoizeTexure_TexelSize;
        float _AnimSpeed;
        float2 _Tiling;
        float4 _MainTex_TexelSize;
        CBUFFER_END
        
        
        // Object and Global properties
        SAMPLER(SamplerState_Linear_Repeat);
        TEXTURE2D(_NoizeTexure);
        SAMPLER(sampler_NoizeTexure);
        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);
        
        // Graph Includes
        // GraphIncludes: <None>
        
        // -- Property used by ScenePickingPass
        #ifdef SCENEPICKINGPASS
        float4 _SelectionID;
        #endif
        
        // -- Properties used by SceneSelectionPass
        #ifdef SCENESELECTIONPASS
        int _ObjectId;
        int _PassValue;
        #endif
        
        // Graph Functions
        
        void Unity_Multiply_float4_float4(float4 A, float4 B, out float4 Out)
        {
            Out = A * B;
        }
        
        void Unity_Multiply_float_float(float A, float B, out float Out)
        {
            Out = A * B;
        }
        
        void Unity_Add_float(float A, float B, out float Out)
        {
            Out = A + B;
        }
        
        void Unity_Divide_float2(float2 A, float2 B, out float2 Out)
        {
            Out = A / B;
        }
        
        void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
        {
            Out = UV * Tiling + Offset;
        }
        
        void Unity_OneMinus_float4(float4 In, out float4 Out)
        {
            Out = 1 - In;
        }
        
        // Custom interpolators pre vertex
        /* WARNING: $splice Could not find named fragment 'CustomInterpolatorPreVertex' */
        
        // Graph Vertex
        struct VertexDescription
        {
            float3 Position;
            float3 Normal;
            float3 Tangent;
        };
        
        VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
        {
            VertexDescription description = (VertexDescription)0;
            description.Position = IN.ObjectSpacePosition;
            description.Normal = IN.ObjectSpaceNormal;
            description.Tangent = IN.ObjectSpaceTangent;
            return description;
        }
        
        // Custom interpolators, pre surface
        #ifdef FEATURES_GRAPH_VERTEX
        Varyings CustomInterpolatorPassThroughFunc(inout Varyings output, VertexDescription input)
        {
        return output;
        }
        #define CUSTOMINTERPOLATOR_VARYPASSTHROUGH_FUNC
        #endif
        
        // Graph Pixel
        struct SurfaceDescription
        {
            float3 BaseColor;
            float Alpha;
        };
        
        SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
        {
            SurfaceDescription surface = (SurfaceDescription)0;
            UnityTexture2D _Property_6c7b10016d0d4be5ab1e65cbc9c8d949_Out_0_Texture2D = UnityBuildTexture2DStructNoScale(_MainTex);
            float4 _UV_9827fc75b2ef4f14a87a38662ecbe5e2_Out_0_Vector4 = IN.uv0;
            float4 _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(_Property_6c7b10016d0d4be5ab1e65cbc9c8d949_Out_0_Texture2D.tex, _Property_6c7b10016d0d4be5ab1e65cbc9c8d949_Out_0_Texture2D.samplerstate, _Property_6c7b10016d0d4be5ab1e65cbc9c8d949_Out_0_Texture2D.GetTransformedUV((_UV_9827fc75b2ef4f14a87a38662ecbe5e2_Out_0_Vector4.xy)) );
            float _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_R_4_Float = _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_RGBA_0_Vector4.r;
            float _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_G_5_Float = _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_RGBA_0_Vector4.g;
            float _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_B_6_Float = _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_RGBA_0_Vector4.b;
            float _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_A_7_Float = _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_RGBA_0_Vector4.a;
            float4 _Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4;
            Unity_Multiply_float4_float4(IN.VertexColor, _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_RGBA_0_Vector4, _Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4);
            float _Split_423e72107c0e4c8c89999de3a93d83e8_R_1_Float = _Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4[0];
            float _Split_423e72107c0e4c8c89999de3a93d83e8_G_2_Float = _Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4[1];
            float _Split_423e72107c0e4c8c89999de3a93d83e8_B_3_Float = _Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4[2];
            float _Split_423e72107c0e4c8c89999de3a93d83e8_A_4_Float = _Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4[3];
            float _Multiply_5267471e9fac471d9849302243409ed9_Out_2_Float;
            Unity_Multiply_float_float(_Split_423e72107c0e4c8c89999de3a93d83e8_A_4_Float, _SampleTexture2D_e4127634d47c45ff81f8f1ad2bb7f7f3_A_7_Float, _Multiply_5267471e9fac471d9849302243409ed9_Out_2_Float);
            UnityTexture2D _Property_880886b5b3874fce93f67e9f062a37e4_Out_0_Texture2D = UnityBuildTexture2DStructNoScale(_NoizeTexure);
            float _Split_809294b7b65d49b38afdb0605beacd6a_R_1_Float = IN.ObjectSpacePosition[0];
            float _Split_809294b7b65d49b38afdb0605beacd6a_G_2_Float = IN.ObjectSpacePosition[1];
            float _Split_809294b7b65d49b38afdb0605beacd6a_B_3_Float = IN.ObjectSpacePosition[2];
            float _Split_809294b7b65d49b38afdb0605beacd6a_A_4_Float = 0;
            float _Property_b77ddee185b444218cf1a2ea81ccabe7_Out_0_Float = _AnimSpeed;
            float _Multiply_fd33e80a53274508a60774ebfbd7dbe9_Out_2_Float;
            Unity_Multiply_float_float(_Property_b77ddee185b444218cf1a2ea81ccabe7_Out_0_Float, IN.TimeParameters.x, _Multiply_fd33e80a53274508a60774ebfbd7dbe9_Out_2_Float);
            float _Add_86e77f7216654a58a7ba4dd1328225e3_Out_2_Float;
            Unity_Add_float(_Split_809294b7b65d49b38afdb0605beacd6a_G_2_Float, _Multiply_fd33e80a53274508a60774ebfbd7dbe9_Out_2_Float, _Add_86e77f7216654a58a7ba4dd1328225e3_Out_2_Float);
            float2 _Vector2_f06f656a2bb34ac5afefc5dbee43ba2a_Out_0_Vector2 = float2(_Split_809294b7b65d49b38afdb0605beacd6a_R_1_Float, _Add_86e77f7216654a58a7ba4dd1328225e3_Out_2_Float);
            float2 _Property_2111e2ba1bb4417baf7304d5fdd89ceb_Out_0_Vector2 = _Tiling;
            float _Float_5b0b401cdc2d4e68bf64323f432e2951_Out_0_Float = 100;
            float2 _Divide_8540f42c2e9c4edfa27bcd5a2bc7ecb2_Out_2_Vector2;
            Unity_Divide_float2(_Property_2111e2ba1bb4417baf7304d5fdd89ceb_Out_0_Vector2, (_Float_5b0b401cdc2d4e68bf64323f432e2951_Out_0_Float.xx), _Divide_8540f42c2e9c4edfa27bcd5a2bc7ecb2_Out_2_Vector2);
            float2 _TilingAndOffset_e5da35fc7fdc4ee1a8a6815dc7ed40fd_Out_3_Vector2;
            Unity_TilingAndOffset_float(_Vector2_f06f656a2bb34ac5afefc5dbee43ba2a_Out_0_Vector2, _Divide_8540f42c2e9c4edfa27bcd5a2bc7ecb2_Out_2_Vector2, float2 (1, 1), _TilingAndOffset_e5da35fc7fdc4ee1a8a6815dc7ed40fd_Out_3_Vector2);
            float4 _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_RGBA_0_Vector4 = SAMPLE_TEXTURE2D(_Property_880886b5b3874fce93f67e9f062a37e4_Out_0_Texture2D.tex, _Property_880886b5b3874fce93f67e9f062a37e4_Out_0_Texture2D.samplerstate, _Property_880886b5b3874fce93f67e9f062a37e4_Out_0_Texture2D.GetTransformedUV(_TilingAndOffset_e5da35fc7fdc4ee1a8a6815dc7ed40fd_Out_3_Vector2) );
            float _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_R_4_Float = _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_RGBA_0_Vector4.r;
            float _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_G_5_Float = _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_RGBA_0_Vector4.g;
            float _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_B_6_Float = _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_RGBA_0_Vector4.b;
            float _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_A_7_Float = _SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_RGBA_0_Vector4.a;
            float4 _OneMinus_43dc4569e72a4775afd88ceb4a5c87ff_Out_1_Vector4;
            Unity_OneMinus_float4(_SampleTexture2D_2046b918deae40c0bc34f8c86742ee3c_RGBA_0_Vector4, _OneMinus_43dc4569e72a4775afd88ceb4a5c87ff_Out_1_Vector4);
            float4 _Multiply_a09e445479bb4032a46668deb4f2b4d2_Out_2_Vector4;
            Unity_Multiply_float4_float4((_Multiply_5267471e9fac471d9849302243409ed9_Out_2_Float.xxxx), _OneMinus_43dc4569e72a4775afd88ceb4a5c87ff_Out_1_Vector4, _Multiply_a09e445479bb4032a46668deb4f2b4d2_Out_2_Vector4);
            surface.BaseColor = (_Multiply_0be0c5b6b5fb45d2b8df6ffb54ac8024_Out_2_Vector4.xyz);
            surface.Alpha = (_Multiply_a09e445479bb4032a46668deb4f2b4d2_Out_2_Vector4).x;
            return surface;
        }
        
        // --------------------------------------------------
        // Build Graph Inputs
        #ifdef HAVE_VFX_MODIFICATION
        #define VFX_SRP_ATTRIBUTES Attributes
        #define VFX_SRP_VARYINGS Varyings
        #define VFX_SRP_SURFACE_INPUTS SurfaceDescriptionInputs
        #endif
        VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
        {
            VertexDescriptionInputs output;
            ZERO_INITIALIZE(VertexDescriptionInputs, output);
        
            output.ObjectSpaceNormal =                          input.normalOS;
            output.ObjectSpaceTangent =                         input.tangentOS.xyz;
            output.ObjectSpacePosition =                        input.positionOS;
        
            return output;
        }
        SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
        {
            SurfaceDescriptionInputs output;
            ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
        
        #ifdef HAVE_VFX_MODIFICATION
        #if VFX_USE_GRAPH_VALUES
            uint instanceActiveIndex = asuint(UNITY_ACCESS_INSTANCED_PROP(PerInstance, _InstanceActiveIndex));
            /* WARNING: $splice Could not find named fragment 'VFXLoadGraphValues' */
        #endif
            /* WARNING: $splice Could not find named fragment 'VFXSetFragInputs' */
        
        #endif
        
            
        
        
        
        
        
            output.ObjectSpacePosition = TransformWorldToObject(input.positionWS);
        
            #if UNITY_UV_STARTS_AT_TOP
            #else
            #endif
        
        
            output.uv0 = input.texCoord0;
            output.VertexColor = input.color;
            output.TimeParameters = _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
        #else
        #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        #endif
        #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
        
                return output;
        }
        
        // --------------------------------------------------
        // Main
        
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/UnlitPass.hlsl"
        
        // --------------------------------------------------
        // Visual Effect Vertex Invocations
        #ifdef HAVE_VFX_MODIFICATION
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/VisualEffectVertex.hlsl"
        #endif
        
        ENDHLSL
        }
    }
}
