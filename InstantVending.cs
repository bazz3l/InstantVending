namespace Oxide.Plugins
{
    [Info("Instant Vending", "Bazz3l", "1.0.0")]
    [Description("Allows players to buy vending items without waiting.")]
    class InstantVending : RustPlugin
    {
        #region Oxide
        object OnBuyVendingItem(NPCVendingMachine machine, BasePlayer player, int sellOrderId, int numberOfTransactions)
        {
            if (machine == null || player == null)
            {
                return null;
            }

            machine.SetPendingOrder(player, sellOrderId, numberOfTransactions);
            machine.Invoke("CompletePendingOrder", 0.1f);

            return false;
        }
        #endregion
    }
}