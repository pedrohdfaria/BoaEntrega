using POC.Controllers.Models;
using System;
using System.Collections.Generic;

namespace POC.Mocks
{
    public static class RouteMock
    {
        public static int GetMockedFuel(Coordinate starting, Coordinate destination)
        {
            int distance = getDistance(starting, destination);

            var random = new Random(distance);
            return distance + random.Next(100);
        }
        public static int GetMockedTime(Coordinate starting, Coordinate destination)
        {
            int distance = getDistance(starting, destination);

            var random = new Random(distance);
            return distance + random.Next(10);
        }

        public static List<string> GetMockedDirections(Coordinate starting, Coordinate destination)
        {
            int quantityOfDirections = getDistance(starting,destination) + 5;
            List<string> directions = getDirections(quantityOfDirections);
            return directions;
        }

        private static int getDistance(Coordinate starting, Coordinate destination)
        {
            double distance = Math.Sqrt(Math.Pow((double)(starting.X - destination.X), 2) + Math.Pow((double)(starting.Y - destination.Y), 2));
            return (int)Math.Ceiling(distance*0.1);
        }

        private static List<string> getDirections(int quantity)
        {
            var random = new Random(quantity);
            List<int> usedDirections = new List<int>();
            var directions = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                int index = random.Next(RandomDirections.Count);
                if(usedDirections.Contains(index)) index = random.Next(RandomDirections.Count);
                usedDirections.Add(index);

                directions.Add(RandomDirections[index]);
            }

            return directions;
        }

        private static List<string> RandomDirections = new List<string> {
            "Siga na direção oeste na R. Freire Farto em direção à R. Gov. Jorge Lacerda",
            "Vire à direita na Rua Marques Perdigão",
            "Vire à esquerda na R. Acácio Vasconcelos",
            "Vire à direita na R. Orlando Murgel",
            "Vire à esquerda na Praça Jorge Alves Brown",
            "Vire à direita na Praça Joubert de Carvalho/R. Padre Arnaldo Pereira",
            "Siga na direção oeste na R. Freire Farto em direção à R. Gov. Jorge Lacerda",
            "Vire à direita na Rua Marques Perdigão",
            "Vire à esquerda na R. Acácio Vasconcelos",
            "Vire à direita na R. Orlando Murgel",
            "Vire à esquerda na Praça Jorge Alves Brown",
            "Vire à direita na Praça Joubert de Carvalho/R. Padre Arnaldo Pereira",
            "Siga na direção lest na R. Freire Farto em direção à R. Gov. Jorge Lacerda",
            "Vire à esquerda na Rua Marques Perdigão",
            "Vire à direita na R. Acácio Vasconcelos",
            "Vire à esquerda na R. Orlando Murgel",
            "Vire à direita na Praça Jorge Alves Brown",
            "Vire à esquerda na Praça Joubert de Carvalho/R. Padre Arnaldo Pereira",
            "Siga na direção leste na R. Freire Farto em direção à R. Gov. Jorge Lacerda",
            "Vire à esquerda na Rua Marques Perdigão",
            "Vire à direita na R. Acácio Vasconcelos",
            "Vire à esquerda na R. Orlando Murgel",
            "Vire à direita na Praça Jorge Alves Brown",
            "Vire à esquerda na Av. Pedro Bueno",
            "Continue para Av. Jornalista Roberto Marinho",
            "Continue em frente para permanecer na Av. Jornalista Roberto Marinho",
            "Você verá Rose Modas (à direita em 750 m)",
            "Mantenha-se à esquerda para permanecer na Av. Jornalista Roberto Marinho",
            "Mantenha-se à direita na bifurcação, siga as indicações para BR-116/R. Bittencourt/SP-280/C. Branco/Pinheiros/Ceagesp e pegue a Marginal Pinheiros",
            "Use a faixa da direita para pegar a rampa de acesso para Lapa/Pte. C. Universitária/SP-270/Rua Tavares",
            "Pegue a BR-116",
            "Pegue a saída em direção a Pça. Panamericana/Lapa",
            "Continue para Av. Dra. Ruth Cardoso",
            "Vire à direita na Praça Arcipreste Anselmo de Oliveira",
            "Siga na direção sul na Rua Antônio Augusto Queiroga em direção à Travessa Júlio Ferro",
            "Continue para R. Francisco de Penalosa",
            "Vire à direita na R. Macedônia",
            "Vire à esquerda na R. João Rodrigues Chaves",
            "Vire à direita na R. Abílio Primo Nalim",
            "Vire à esquerda na R. dos Morgados",
            "Continue para Praça Dona Amália G. Solitari",
            "Vire à esquerda na Av. Gen. Edgar Facó",
            "Curva suave à direita na R. Benedito Monteiro",
            "R. Benedito Monteiro faz uma curva suave à direita e se torna R. Balsa",
            "Continue para R. Manuel de Carvalho",
            "Vire à esquerda na R. Miguel Téles",
            "Vire à direita para permanecer na R. Miguel Téles",
            "Curva suave à direita na Av. Otaviano Alves de Lima",
            "Mantenha-se à direita para continuar na Av. Marginal Direita do Tietê",
            "Mantenha-se à direita para continuar na Av. Marginal Direita do Tietê",
            "Continue para Av. Pres. Kenedy",
            "Use as duas faixas da esquerda para virar levemente à esquerda Estrada com pedágio",
            "Use as duas faixas da direita e pegue a saída 21 em direção a Tamboré/Carapicuíba",
            "Mantenha-se à esquerda para continuar na direção de Av. Piracema",
            "Mantenha-se à esquerda, siga as indicações para Carapicuiba e pegue a Av. Piracema",
            "Siga na direção norte na Av. Marginal do Ribeirão em direção à Av. dos Autonomistas",
            "Vire à direita na Av. dos Autonomistas (placas para Osasco)",
            "Você verá B2 Surf Shop Outlet - Km 18 (à direita em 2,3 km)",
            "Use as duas faixas da direita e pegue a saída em direção a Universidade Federal/Campus Osasco",
            "Continue para Av. Sport Club Corinthians Paulista",
            "Vire à esquerda para permanecer na Av. Sport Club Corinthians Paulista",
            "Vire à esquerda na Av. Visc. de Nova Granada",
            "Continue para Viaduto Pres. Dr. Tancredo de Almeida Neves",
            "Use a faixa da direita para pegar a rampa de acesso para Pres. Altino/Marginais",
            "Pegue a Av. das Nações Unidas",
            "Siga na direção norte na R. César Pereira das Neves em direção à Av. Dep. Cantídio Sampaio",
            "Vire à esquerda na 1ª rua transversal para Av. Dep. Cantídio Sampaio",
            "Você verá Bar e Restaurante Cozinha Baiana (à esquerda)",
            "Vire à direita na Rua Antônio Nápola",
            "Vire à esquerda na R. João Batista Dias",
            "Vire à direita na Av. Raimundo Pereira de Magalhães",
            "Curva suave à esquerda",
            "Use a faixa da direita para virar levemente à esquerda e acessar a Av. Raimundo Pereira de Magalhães",
            "Siga na direção norte na R. César Pereira das Neves em direção à Av. Dep. Cantídio Sampaio",
            "Vire à direita na Av. Dep. Cantídio Sampaio",
            "Você verá Bazar & Papelaria Princesa (à esquerda em 3,2 km)",
            "Curva suave à direita na Av. Inajar de Souza",
            "Use as duas faixas da direita para virar levemente à direita e acessar a Rodoanel Mário Covas ",
            "Pegue a Rod. dos Bandeirantes",
            "Use a segunda pista mais à direita e pegue a saída em direção a Marginal Pinheiros/SP-280/Castello Branco/SP-160/Imigrantes",
            "Mantenha-se à esquerda, siga as indicações para Marg. Pinheiros/Congonhas Airport/SP-280/C. Branco/SP-270/R. Tavares e pegue a BR-116",
            "Mantenha-se à esquerda para continuar na BR-116 e siga as indicações para Marg. Pinheiros/SP-160/Imigrantes/SP-150/Anchieta",
            "Continue em frente para permanecer na BR-116",
            "Mantenha-se à esquerda para continuar na Marginal Pinheiros",
            "Use as duas faixas da esquerda para virar levemente à esquerda e permanecer na Marginal Pinheiros",
            "Mantenha-se à esquerda para permanecer na Marginal Pinheiros",
            "Use as duas faixas da direita para virar levemente à direita e acessar a Pte. Eng. Ari Torres",
            "Pte. Eng. Ari Torres faz uma curva suave à esquerda e se torna Av. dos Bandeirantes",
            "Continue para Pte. Eng. Ari Torres",
            "Continue para Av. dos Bandeirantes",
            "Continue para Pte. Eng. Ari Torres",
            "Use as três faixas da esquerda para virar levemente à esquerda e acessar a Av. dos Bandeirantes",
            "Você verá Riolax São Paulo (à direita em 800 m)",
            "Continue para Av. Afonso D'Escragnolle Taunay",
            "Continue em frente para permanecer na Av. Afonso D'Escragnolle Taunay",
            "Continue para Viaduto Min. Aliomar Baleeiro",
            "Continue para Complexo Viário Maria Maluf",
            "Pegue a Via Lateral-Norte",
            "Continue em frente",
            "Mantenha-se à direita",
            "Pegue a saída 212 em direção a Jd. M. Dirce/V. Paraiso/Pq. Alvorada",
            "Vire à direita na Av. Santa Helena",
            "Vire à direita depois de Drogaria Guarulhos (Vila Paraíso) (à direita)",
            "Continue em frente na R. Santa Elizabete",
            "Vire à esquerda na Av. José Miguel Ackel",
            "Continue em frente",
            "Mantenha-se à direita",
            "Continue em frente",
            "Mantenha-se à esquerda",
            "Vire à direita em 200m",
            "Vire à direita em 300m",
            "Vire à direita em 400m",
            "Vire à direita em 500m",
            "Vire à direita em 600m",
            "Vire à direita em 700m",
            "Vire à direita em 800m",
            "Vire à esquerda em 200m",
            "Vire à esquerda em 300m",
            "Vire à esquerda em 400m",
            "Vire à esquerda em 500m",
            "Vire à esquerda em 600m",
            "Vire à esquerda em 700m",
            "Vire à esquerda em 800m",
            "Vire à direita e logo em seguida esquerda em 200m",
            "Vire à direita e logo em seguida esquerda em 300m",
            "Vire à direita e logo em seguida esquerda em 400m",
            "Vire à direita e logo em seguida esquerda em 500m",
            "Vire à direita e logo em seguida esquerda em 600m",
            "Vire à direita e logo em seguida esquerda em 700m",
            "Vire à direita e logo em seguida esquerda em 800m",
            "Vire à esquerda e logo em seguida direita em 200m",
            "Vire à esquerda e logo em seguida direita em 300m",
            "Vire à esquerda e logo em seguida direita em 400m",
            "Vire à esquerda e logo em seguida direita em 500m",
            "Vire à esquerda e logo em seguida direita em 600m",
            "Vire à esquerda e logo em seguida direita em 700m",
            "Vire à esquerda e logo em seguida direita em 800m",
            "Siga em frente por 100m",
            "Siga em frente por 200m",
            "Siga em frente por 300m",
            "Siga em frente por 400m",
            "Siga em frente por 500m",
            "Siga em frente por 600m",
            "Siga em frente por 700m",
            "Siga em frente por 800m",
            "Siga em frente por 900m",
            "Siga em frente por 100m",
            "Siga em frente por 200m",
            "Siga em frente por 120m",
            "Siga em frente por 250m"
        };
    }
}
