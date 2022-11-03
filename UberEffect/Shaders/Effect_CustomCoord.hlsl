#ifndef EFFECT_CUSTOMCOORD_INCLUDE
#define EFFECT_CUSTOMCOORD_INCLUDE

#if defined(CUSTOM_TWEEN_SYSTEM)
//use custom tween system
#define INPUT_CUSTOM_COORD(index1, index2)
#define SETUP_CUSTOM_COORD(input,coordName1,coordName2) float4 customCoords[] = \
{ \
float4(0.0, 0.0, 0.0, 0.0), \
coordName1, \
coordName2 \
};
#define TRANSFER_CUSTOM_COORD(input, output)
#define DECLARE_CUSTOM_COORD(propertyName) uniform half propertyName;
#define GET_CUSTOM_COORD(propertyName) customCoords[(uint)propertyName % 10][(uint)propertyName / 10]
#define GET_CUSTOM_COORD_DIRECT(coordIndex, swizzleIndex) customCoords[coordIndex][swizzleIndex]

#else
//use particle system
#define INPUT_CUSTOM_COORD(index1, index2) float4 customCoord1: TEXCOORD##index1; \
float4 customCoord2: TEXCOORD##index2;
#define SETUP_CUSTOM_COORD(input,coordName1,coordName2) float4 customCoords[] = \
{ \
float4(0.0, 0.0, 0.0, 0.0), \
input.customCoord1, \
input.customCoord2 \
};
#define TRANSFER_CUSTOM_COORD(input, output) output.customCoord1 = input.customCoord1; \
output.customCoord2 = input.customCoord2;
#define DECLARE_CUSTOM_COORD(propertyName) uniform half propertyName;
#define GET_CUSTOM_COORD(propertyName) customCoords[(uint)propertyName % 10][(uint)propertyName / 10]
#define GET_CUSTOM_COORD_DIRECT(coordIndex, swizzleIndex) customCoords[coordIndex][swizzleIndex]

#endif

#endif