# Part

|Name|Type|Description|
|---|---|---|
|`tag`|string|This is just a tag you can set, and currently it does nothing. It will probably do something in the future though.|
|`id`|int|This is the part ID, a unique integer used to reference it from elsewhere.|
|`partType`|string|Which type the part is.|
|`position`|Vector3|The position of the part.|
|`rotation`|Vector3|Euler angles representing the part's rotation.|
|`name`|string|This is the name field you can set in the designer. It doesn't do overly much|
|`themeId`|GUID|This is not used in a saved craft file from the editor, but in a saved craft from the sandbox. It indicates which theme the part uses (because multiple crafts with different themes can dock into one craft, which then has multiple themes.)|
|`activated`|bool|If the part is activated or not. Usually `false`, used in sandbox saves.|
|`activationGroup`|int|The activation group that will activate the part.|
|`previouslyActivated`|bool|If the part has been activated before.|
|`activationStage`|int|The index of the stage that, when triggered, will activate the part.|
|`stageOverride`|bool|If the stage has been overriden by the user. If `false`, then the game will try and auto-calculate the stage.|
|`rootPart`|bool|If `true`, this part is the root (primary command chip/pod).|
|`commandPodId`|int|The ID of the part's "root part", or command chip/pod in other words. Normally used in the sandbox for docked crafts.|
|`materials`|list|A list of integers, comma separated, indicating the material IDs of the Primary, Trim 1, Trim 2, etc slots. This can be as short as you like if only the first slots are used.|
|`symmetryId`|GUID|The GUID of the symmetry group the part is in.|
|`mirrored`|bool|Whether or not the part has been mirrored (reflected).|
|`damage`|float|How much damage the part has taken. The part will be destroyed when this reaches `Config.maxDamage`|
|`style`|string|The style to use. For instance the style of Interstage. This affects which model is used. Note that this option, as well as the three below it, can be repeated for each "Sub Part" on the part. For instance, the jet engine has both `shroudStyle` and `nozzleStyle`.|
|`texture`|string|The texture to use. Can be repeated, see `style` above.|
|`textureTiling`|Vector2|How many repeats of the texture to tile. Can be repeated, see `style` above.|
|`textureOffset`|Vector2|The offset of the texture tiling. Can be repeated, see `style` above.|