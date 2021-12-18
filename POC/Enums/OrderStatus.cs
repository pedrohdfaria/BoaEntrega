namespace POC.Entities
{
    public enum OrderStatus
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
