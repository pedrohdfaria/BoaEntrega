namespace POC.Entities
{
    public enum StatusPedido
    {
        Pendente,
        AguardandoPagamento,
        PagamentoAprovadoViaPix,
        PagamentoAprovadoViaCartaoCredito,
        PagamentoAprovadoViaTransferencia,
        ProdutosEmSeparacao,
        AguardandoEmissaoNotaFiscal,
        AguardandoColetaTransportador,
        EnviadoATransportador,
        EmRotaParaDestino,
        Entregue
    }
}
