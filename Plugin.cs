using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using PlayerRoles;
using InventorySystem.Items; // для ItemType

namespace ChaosSpy
{
    public class ChaosSpyPlugin : Plugin<Config>
    {
        public override string Name
        {
            get { return "ChaosSpy"; }
        }

        public override string Author
        {
            get { return "Lancer"; }
        }

        public override Version Version
        {
            get { return new Version(1, 0, 0); }
        }

        private static readonly Random Random = new Random();

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            base.OnDisabled();
        }

        private void OnVerified(VerifiedEventArgs ev)
        {
            if (!Config.IsEnabled)
                return;

            if (Random.NextDouble() <= Config.SpyChance)
            {
                // Меняем роль на Д-класс
                ev.Player.Role.Set(RoleTypeId.ClassD);

                // Выдаем карту Хаоса
                ev.Player.AddItem(ItemType.KeycardChaosInsurgency);

                // HUD сообщение
                ev.Player.Broadcast(5, "🕵️ Ты — <color=green>Шпион Хаоса</color>! 🤫");
            }
        }
    }
}