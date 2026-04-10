namespace DarkSoulCollector.Core
{
    /// <summary>
    /// Global constants: tags, layers, animation params, scene names.
    /// </summary>
    public static class Constants
    {
        // Tags
        public const string TAG_PLAYER = "Player";
        public const string TAG_ENEMY = "Enemy";
        public const string TAG_NPC = "NPC";
        public const string TAG_ITEM = "Item";

        // Scenes
        public const string SCENE_MAIN_MENU = "MainMenu";
        public const string SCENE_GAMEPLAY = "Gameplay";
        public const string SCENE_LOADING = "Loading";

        // Animation Parameters
        public const string ANIM_SPEED = "Speed";
        public const string ANIM_ATTACK = "Attack";
        public const string ANIM_HURT = "Hurt";
        public const string ANIM_DEAD = "Dead";
    }
}
