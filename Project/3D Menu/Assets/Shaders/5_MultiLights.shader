﻿Shader "unityCookie/Beginner/5A_MultiLights" {
	Properties{
		_Color("Color", Color) = (1.0, 1.0,1.0,1.0)
		_SpecColor("Specular Color", Color) = (1.0, 1.0,1.0,1.0)
		_Shininess ("Shininess", Float) = 10
		_RimColor ("Rime Color", Color) = (1.0,1.0,1.0,1.0)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0
	}	
		SubShader{
			Pass{
			Tags {"LightMode" = "ForwardBase"}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			//User defined variables
			uniform float4 _Color; 
			uniform float4 _RimColor;
			uniform float4 _SpecColor;
			uniform float _Shininess; 
			uniform float _RimPower; 
			
			//Unity defiend variables
			uniform float4 _LightColor0; 
			
			//Base input structs 
			struct vertexInput{
			float4 vertex : POSITION; 
			float3 normal : NORMAL;
			};
			
			struct vertexOutput{
			float4 pos : SV_POSITION; 
			float4 posWorld : TEXCOORD0;
			float3 normalDir : TEXCOORD1;
			};
			
			vertexOutput vert (vertexInput v){
				vertexOutput o; 
				o.posWorld = mul (_Object2World, v.vertex); 
				o.normalDir = normalize (mul ( float4(v.normal, 0.0), _World2Object).xyz); 
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				return o; 
			}
			
			
			//fragment function 
			float4 frag(vertexOutput i ) : COLOR
			{
				float3 normalDirection = i.normalDir; 
				float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz); 
				float3 lightDirection = normalize (_WorldSpaceLightPos0.xyz); 
				float3 atten = 1.0; 
				
				//lighting
				float3 diffuseReflection = atten * _LightColor0 * saturate(dot ( normalDirection
																, lightDirection));
				float3 specularReflection = atten * _LightColor0.xyz 
											* max(0.0, dot ( normalDirection, lightDirection))
											* pow (max (0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);
				
				//Rim Lighthing 
				float rim = 1-saturate(dot(normalize(viewDirection), normalDirection));
				float3 rimLighting = saturate (dot (normalDirection, lightDirection)) * pow(rim, _RimPower)
									* _RimColor * atten * _LightColor0;
				
				float3 lightFinal = rimLighting + diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT.rgb; 
				//lightFinal = specularReflection + diffuseReflection + UNITY_LIGHTMODEL_AMBIENT; 
				
				return float4(lightFinal * _Color.xyz, 1.0); 
			}
			
			ENDCG
			}

			Pass{
				Tags{ "LightMode" = "ForwardAdd" }
				Blend One One
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				//User defined variables
				uniform float4 _Color;
				uniform float4 _RimColor;
				uniform float4 _SpecColor;
				uniform float _Shininess;
				uniform float _RimPower;

				//Unity defiend variables
				uniform float4 _LightColor0;

				//Base input structs 
				struct vertexInput {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};

				struct vertexOutput {
					float4 pos : SV_POSITION;
					float4 posWorld : TEXCOORD0;
					float3 normalDir : TEXCOORD1;
				};

				vertexOutput vert(vertexInput v) {
					vertexOutput o;
					o.posWorld = mul(_Object2World, v.vertex);
					o.normalDir = normalize(mul(float4(v.normal, 0.0), _World2Object).xyz);
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					return o;
				}


				//fragment function 
				float4 frag(vertexOutput i) : COLOR
				{
					float3 normalDirection = i.normalDir;
					float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
					float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
					float3 atten = 1.0;

					//lighting
					float3 diffuseReflection = atten * _LightColor0 * saturate(dot(normalDirection
						, lightDirection));
					float3 specularReflection = atten * _LightColor0.xyz
						* max(0.0, dot(normalDirection, lightDirection))
						* pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);

					//Rim Lighthing 
					float rim = 1 - saturate(dot(normalize(viewDirection), normalDirection));
					float3 rimLighting = saturate(dot(normalDirection, lightDirection)) * pow(rim, _RimPower)
						* _RimColor * atten * _LightColor0;

					float3 lightFinal = rimLighting + diffuseReflection + specularReflection;
					//lightFinal = specularReflection + diffuseReflection + UNITY_LIGHTMODEL_AMBIENT; 

					return float4(lightFinal * _Color.xyz, 1.0);
				}

					ENDCG
				}
	}

}