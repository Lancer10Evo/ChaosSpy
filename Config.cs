using Exiled.API.Interfaces;

namespace ChaosSpy
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false; // <--- добавляем

        // Шанс стать шпионом хаоса (0.35 = 35%)
        public double SpyChance { get; set; } = 0.35;
    }
}