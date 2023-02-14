Asset for creating a background with parallax.

C# script BackGround contain:
First you need to create a scriptableObject BackgroundSettings - it is needed to create and configure the background prefab.
    - BackgroundSettings:
        public string BackgroundName = "Background" - background prefab name
        public bool NineImage - if true, created nineImage parallax
        public string Layer = "Background"; - used layer name. You need create layer before use it
        public List<BackgroundLayerSetting> BackgroundLayerSettings; - config with parallax speed and sprite
        
        After fill all fields press button on scriptable Create background prefab.
        in this path created prefab Assets/Parallax2D/Modules/Background/Prefabs with name from field BackgroundName
        
    - InitializeBackground - example how set dependencies into background Parallax and init it.
         
        