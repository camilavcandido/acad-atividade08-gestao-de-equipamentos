using System;

namespace ControleDeEquipamentos.ConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region declaração de variaveis
            string opcaoMenu;
            string continuar;
            string[] nomeEquipamento = new string[1000];
            string[] numeroSerie = new string[1000];
            decimal[] precoEquipamento = new decimal[1000];
            string[] dataFabricacao = new string[1000];
            string[] nomeFabricante = new string[1000];
            bool[] temChamado = new bool[1000];
            int indice = 0;
            int[] idChamado = new int[1000];
            string[] tituloChamado = new string[1000];
            string[] descricaoChamado = new string[1000];
            string[] dataAberturaChamado = new string[1000];
            int indiceChamado = 0;
            int geraid = 1;
            bool[] statusChamado = new bool[1000];
            #endregion

            do
            {

                opcaoMenu = ApresentaMenu();

                switch (opcaoMenu)
                {
                    case "1":
                        do
                        {
                            continuar = RegistraEquipamento(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado, ref indice);
                        } while (continuar == "S");
                        Console.Clear();
                        break;
                    case "2":
                        ExibeEquipamentosRegistrados(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado, ref indice);
                        break;
                    case "3":
                        EditaEquipamento(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado);
                        break;
                    case "4":
                        ExcluiEquipamento(ref nomeEquipamento, ref numeroSerie, ref precoEquipamento, ref dataFabricacao, ref nomeFabricante, ref temChamado);
                        break;
                    case "5":
                        RegistrarChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref geraid, ref statusChamado);
                        break;
                    case "6":
                        ExibeChamados(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "7":
                        EditaChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "8":
                        ExcluiChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                }


            } while (1 == 1);


            #region metodos
            static string ApresentaMenu()
            {
                string opcaoMenu;
                TituloMenu();
                Console.WriteLine("" +
                    "\t1 - Registrar Novo Equipamento\n" +
                    "\t2 - Visualizar os Equipamentos Registrados\n" +
                    "\t3 - Editar Equipamento\n" +
                    "\t4 - Excluir Equipamento\n" +
                    "\t5 - Registrar Chamado de Manutenção\n" +
                    "\t6 - Visualizar os Chamados Registrados\n" +
                    "\t7 - Editar Chamado\n" +
                    "\t8 - Excluir Chamado\n" +
                    "\t9 - Sair");
                ApresentaMensagemEntradaDeDados("\tEscolha uma opção: ", ConsoleColor.Blue);
                opcaoMenu = Console.ReadLine();
                while (opcaoMenu != "1" && opcaoMenu != "2" && opcaoMenu != "3" && opcaoMenu != "4" &&
                    opcaoMenu != "5" && opcaoMenu != "6" && opcaoMenu != "7" && opcaoMenu != "8" && opcaoMenu != "9")
                {
                    ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                    ApresentaMensagemEntradaDeDados("\tEscolha uma opção: ", ConsoleColor.Blue);
                    opcaoMenu = Console.ReadLine();
                }
                return opcaoMenu;
            }

            static string RegistraEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado, ref int indice)
            {
                string continuar;

                TituloSecao("1 - Registrar Novo Equipamento");

                NomeInput("Digite o Nome:");
                nomeEquipamento[indice] = Console.ReadLine();
                VerificaQuantidadeCaracteres(ref nomeEquipamento, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Número de Série (S/N):");
                numeroSerie[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Preço:");
                precoEquipamento[indice] = decimal.Parse(Console.ReadLine());
                VerificaPrecoEhPositivo(ref precoEquipamento, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Data de Fabricação\n");
                ValidaDataFabricacao(ref dataFabricacao, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Fabricante:");
                nomeFabricante[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                temChamado[indice] = false;

                indice++;

                ApresentaMensagem("\n\tEquipamento registrado com sucesso!", ConsoleColor.Green);

                Console.WriteLine("\n\tDeseja registrar outro equipamento? Digite S para sim ou N para não");
                ApresentaMensagemEntradaDeDados("\tEscolha uma opção: ", ConsoleColor.Blue);

                continuar = Console.ReadLine();

                return continuar;
            }

            static void VerificaQuantidadeCaracteres(ref string[] nomeEquipamento, ref int indice)
            {
                while (nomeEquipamento[indice].Length < 6)
                {
                    ApresentaMensagem("O nome do equipamento deve ter no minimo 6 caracteres", ConsoleColor.Red);
                    NomeInput("Digite o Nome:");
                    nomeEquipamento[indice] = Console.ReadLine();
                }
            }

            static void ExibeEquipamentosRegistrados(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado, ref int indice)
            {
                string espaco = "        ";

                TituloSecao("2 - Visualizar os Equipamentos Registrados");

                if (indice == 0)
                    ApresentaMensagem("Não há equipamentos registrados. Digite qualquer tecla para retornar ao menu", ConsoleColor.Red);

                else
                {
                    for (int i = 0; i < indice; i++)
                    {
                        if (numeroSerie[i] != null)
                        {
                            ImprimeLinhaEmBranco();
                            NomeCampo("Nome: ");
                            Console.Write(nomeEquipamento[i] + espaco);
                            NomeCampo("Nº Série: ");
                            Console.Write(numeroSerie[i] + espaco);
                            NomeCampo("Fabricante: ");
                            Console.Write(nomeFabricante[i] + espaco);
                            NomeCampo("Tem chamado: ");
                            Console.Write(temChamado[i]);
                            ImprimeLinhaEmBranco();
                        }
                    }

                    ApresentaMensagem("\n\tListagem de Equipamentos finalizada! Digite qualquer tecla para retornar ao menu", ConsoleColor.DarkGreen);
                }
                Console.ReadLine();
            }

            static void EditaEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado)
            {
                #region variaveis
                string numeroSerieSelecionado;
                bool numeroSerieExiste = false;
                int indice;
                #endregion

                TituloSecao("3 - Editar Equipamento");

                NomeInput("Digite o Nº de Série (S/N) do equipamento que deseja editar:");
                numeroSerieSelecionado = Console.ReadLine();
                ImprimeLinhaEmBranco();

                for (int i = 0; i < numeroSerie.Length; i++)
                {

                    if (numeroSerieSelecionado == numeroSerie[i])
                    {
                        numeroSerieExiste = true;
                        indice = i;

                        ApresentaMensagem("Editando Equipamento Nº Série (S/N) = " + numeroSerie[i], ConsoleColor.Blue);

                        NomeInput("Digite o novo Nome:");
                        nomeEquipamento[indice] = Console.ReadLine();
                        VerificaQuantidadeCaracteres(ref nomeEquipamento, ref indice);
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Número de Série (S/N) :");
                        numeroSerie[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Preço:");
                        precoEquipamento[i] = decimal.Parse(Console.ReadLine());
                        VerificaPrecoEhPositivo(ref precoEquipamento, ref indice);
                        ImprimeLinhaEmBranco();

                        NomeInput("Data de Fabricação\n");
                        ValidaDataFabricacao(ref dataFabricacao, ref indice);
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Fabricante:");
                        nomeFabricante[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        ApresentaMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
                    }
                }

                if (numeroSerieExiste == false)
                    ApresentaMensagem("Equipamento não encontrado, verifique o Número de Série (S/N) e tente novamente!", ConsoleColor.Red);
                Console.ReadLine();
            }

            static void ExcluiEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado)
            {


                #region var
                string numeroSerieSelecionado, confirmacao;
                bool numeroSerieExiste = false;
                #endregion

                TituloSecao("4 - Excluir Equipamento");


                NomeInput("Digite o Número de Série (S/N) do Equipamento que deseja excluir:");
                numeroSerieSelecionado = Console.ReadLine();

                for (int i = 0; i < numeroSerie.Length; i++)
                {
                    if (numeroSerie[i] == numeroSerieSelecionado)
                    {
                        numeroSerieExiste = true;

                        if (temChamado[i] == true)
                        {
                            ApresentaMensagem("Não é possível excluir o equipamento que possuí chamado em aberto.", ConsoleColor.Red);
                        }
                        else if (temChamado[i] == false)
                        {

                            ApresentaMensagem("Deseja remover o equipamento com Nº de série " + numeroSerie[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                            confirmacao = Console.ReadLine();
                            while (confirmacao != "S" && confirmacao != "N")
                            {
                                ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                                ApresentaMensagem("Deseja remover o equipamento com Nº de série " + numeroSerie[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                                confirmacao = Console.ReadLine();
                            }

                            if (confirmacao == "S")
                            {
                                nomeEquipamento[i] = null;
                                numeroSerie[i] = null;
                                precoEquipamento[i] = 0;
                                dataFabricacao[i] = null;
                                nomeFabricante[i] = null;
                                ApresentaMensagem("Equipamento removido!", ConsoleColor.Green);
                            }
                            else if (confirmacao == "N")
                            {
                                ApresentaMensagem("Operação cancelada!", ConsoleColor.Yellow);

                            }
                        }
                    }
                }

                if (numeroSerieExiste == false)
                    ApresentaMensagem("Equipamento não encontrado, verifique o Número de Série (S/N) e tente novamente!", ConsoleColor.Red);

                Console.ReadLine();
            }

            static void RegistrarChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado,
                ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref int geraid, ref bool[] statusChamado)
            {
                string numeroSerieSelecionado;
                bool numeroSerieExiste = false;

                TituloSecao("5 - Registrar Chamado de Manutenção");

                NomeInput("Digite o Número de Série (S/N) do Equipamento:");
                numeroSerieSelecionado = Console.ReadLine();
                ImprimeLinhaEmBranco();

                for (int i = 0; i < numeroSerie.Length; i++)
                {

                    if (numeroSerie[i] == numeroSerieSelecionado)
                    {

                        numeroSerieExiste = true;

                        NomeInput("Digite o Título do Chamado:");
                        tituloChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a Descrição do Chamado:");
                        descricaoChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Data de Abertura do Chamado\n");
                        ValidaDataChamado(ref dataAberturaChamado, ref indiceChamado);
                        ImprimeLinhaEmBranco();

                        idChamado[indiceChamado] = geraid;

                        temChamado[i] = true;

                        statusChamado[i] = true;

                        indiceChamado++;

                        ApresentaMensagem("Chamado registrado com sucesso!", ConsoleColor.Green);

                        geraid++;

                    }

                }
                if (numeroSerieExiste == false)
                    ApresentaMensagem("Equipamento não encontrado, verifique o Número de Série (S/N) e tente novamente!", ConsoleColor.Red);
                Console.ReadLine();

            }

            static void ExibeChamados(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                string espaco = "        ";

                TituloSecao("6 - Visualizar os Chamados Registrados");

                if (indiceChamado == 0)
                {
                    ApresentaMensagem("Não há chamados registrados!", ConsoleColor.Red);
                Console.ReadLine();


                }

                else
                {
                    for (int i = 0; i < indiceChamado; i++)
                    {
                        if (statusChamado[i]==true)
                        {
                            ImprimeLinhaEmBranco();
                            NomeCampo("ID: ");
                            Console.Write(idChamado[i] + espaco);
                            NomeCampo("Titulo: ");
                            Console.Write(tituloChamado[i] + espaco);
                            NomeCampo("Equipamento (S/N): ");
                            Console.Write(numeroSerie[i] + espaco);
                            NomeCampo("Data de Abertura: ");
                            Console.Write(dataAberturaChamado[i] + espaco);


                            string strData = dataAberturaChamado[i];
                            DateTime DateObject = Convert.ToDateTime(strData);
                            TimeSpan diasEmAberto = DateTime.Today - DateObject;

                            NomeCampo("Dias em Aberto: ");
                            Console.Write(diasEmAberto.TotalDays);



                        }
                    }
                    ApresentaMensagem("\n\tListagem de Chamados finalizada! Digite qualquer tecla para retornar ao menu", ConsoleColor.DarkGreen);
                }
                Console.ReadLine();

            }

            static void EditaChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                bool chamadoExiste = false;
                bool numeroSerieExiste = false;
                string numeroSerieSelecionado;
                TituloSecao("7 - Editar Chamado");
                ImprimeLinhaEmBranco();

               
                NomeInput("Digite o ID do Chamado que deseja editar:");
                int chamadoSelecionado = int.Parse(Console.ReadLine());

                for (int i = 0; i < idChamado.Length; i++)
                {

                    if (chamadoSelecionado == idChamado[i]) 
                        if (chamadoSelecionado == idChamado[i])
                        {
                            chamadoExiste = true;
                            ApresentaMensagem("Editando Chamado ID = " + idChamado[i], ConsoleColor.Blue);
                            NomeInput("Digite o Número de Série do Equipamento:");
                            numeroSerieSelecionado = Console.ReadLine();
                            if (numeroSerieSelecionado == numeroSerie[i])
                            {
                                numeroSerieExiste = true;
                                ImprimeLinhaEmBranco();
                                NomeInput("Digite o novo Titulo do Chamado:");
                                tituloChamado[i] = Console.ReadLine();
                                ImprimeLinhaEmBranco();
                                NomeInput("Digite a nova Descrição do Chamado:");
                                descricaoChamado[i] = Console.ReadLine();
                                ImprimeLinhaEmBranco();

                                NomeInput("Data de Abertura do Chamado\n");
                                ValidaDataChamado(ref dataAberturaChamado, ref indiceChamado);
                                ImprimeLinhaEmBranco();

                                ApresentaMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
                            }

                        }
                }
                if (chamadoExiste == false)
                {
                    ApresentaMensagem("Chamado não encontrado! Verifique o ID do Chamado e tente novamente!", ConsoleColor.Red);
                }
                else if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Verifique o Nº de Série e tente novamente!", ConsoleColor.Red);
                }
                Console.ReadLine();
            }

            static void ExcluiChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {

                int idChamadoSelecionado;
                bool idChamadoExiste = false;
                string confirmacao;

                TituloSecao("8 - Excluir Chamado");

                NomeInput("Digite o ID do Chamado que deseja excluir: ");
                idChamadoSelecionado = int.Parse(Console.ReadLine());

                for (int i = 0; i < idChamado.Length; i++)
                {
                    if (idChamadoSelecionado == idChamado[i])
                    {
                        idChamadoExiste = true;

                        if (statusChamado[i] == true)
                        {
                            ApresentaMensagem("Deseja remover o chamado ID = " + idChamado[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                            confirmacao = Console.ReadLine();
                            while (confirmacao != "S" && confirmacao != "N")
                            {
                                ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                                ApresentaMensagem("Deseja remover o chamado ID = " + idChamado[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                                confirmacao = Console.ReadLine();
                            }
                            if (confirmacao == "S")
                            {
                                idChamado[i] = 0;
                                temChamado[i] = false;
                                statusChamado[i] = false;
                                ApresentaMensagem("Chamado removido com sucesso!", ConsoleColor.Green);
                            }
                            else if (confirmacao == "N")
                            {
                                ApresentaMensagem("Operação cancelada!", ConsoleColor.Yellow);

                            }
                        }


                    }
                }

                if (idChamadoExiste == false)
                {
                    ApresentaMensagem("Chamado não encontrado, verifique o ID do Chamado e tente novamente!", ConsoleColor.Red);
                }
                Console.ReadLine();
            }


            static void VerificaPrecoEhPositivo(ref decimal[] precoEquipamento, ref int indice)
            {
                while (precoEquipamento[indice] <= -0)
                {
                    ApresentaMensagem("O Preço do Equipamento deve ser decimal, positivo e maior que zero", ConsoleColor.Red);
                    NomeInput("Digite o Preço:");
                    precoEquipamento[indice] = decimal.Parse(Console.ReadLine());

                }
            }

            static void ValidaDataChamado(ref string[] dataAberturaChamado, ref int indiceChamado)
            {
                NomeInput("Digite o dia (dd):");
                int dia = int.Parse(Console.ReadLine());
                while (dia <= 0 || dia > 31)
                {
                    ApresentaMensagem("É permitido valores entre 01 e 31", ConsoleColor.Red);
                    NomeInput("Digite o dia (dd):");
                    dia = int.Parse(Console.ReadLine());
                }
                NomeInput("Digite o mês (mm):");
                int mes = int.Parse(Console.ReadLine());
                while (mes < 1 || mes > 12)
                {
                    ApresentaMensagem("É permitido valores entre 01 e 12", ConsoleColor.Red);
                    NomeInput("Digite o mês (mm):");
                    mes = int.Parse(Console.ReadLine());
                }
                NomeInput("Digite o ano (aaaa):");
                int ano = int.Parse(Console.ReadLine());
                while (ano < 2000 || ano > 2022)
                {
                    ApresentaMensagem("É permitido valores entre 2000 e 2022", ConsoleColor.Red);
                    NomeInput("Digite o ano (aaaa):");
                    ano = int.Parse(Console.ReadLine());
                }

                DateTime date = new DateTime(ano, mes, dia);

                dataAberturaChamado[indiceChamado] = Convert.ToString(date);
               

            }

            static void ValidaDataFabricacao(ref string[] dataFabricacao, ref int indice)
            {
                NomeInput("Digite o dia (dd):");
                int dia = int.Parse(Console.ReadLine());
                while (dia <= 0 || dia > 31)
                {
                    ApresentaMensagem("É permitido valores entre 01 e 31", ConsoleColor.Red);
                    NomeInput("Digite o dia (dd):");
                    dia = int.Parse(Console.ReadLine());
                }
                NomeInput("Digite o mês (mm):");
                int mes = int.Parse(Console.ReadLine());
                while (mes < 1 || mes > 12)
                {
                    ApresentaMensagem("É permitido valores entre 01 e 12", ConsoleColor.Red);
                    NomeInput("Digite o mês (mm):");
                    mes = int.Parse(Console.ReadLine());
                }
                NomeInput("Digite o ano (aaaa):");
                int ano = int.Parse(Console.ReadLine());
                while (ano < 2000 || ano > 2022)
                {
                    ApresentaMensagem("É permitido valores entre 2000 e 2022", ConsoleColor.Red);
                    NomeInput("Digite o ano (aaaa):");
                    ano = int.Parse(Console.ReadLine());
                }

                DateTime dataF = new DateTime(ano, mes, dia);

                dataFabricacao[indice] = Convert.ToString(dataF);

                //  Console.WriteLine(dataFabricacao[indice]);
            }


            #endregion

            #region  

            static void ApresentaMensagem(string mensagem, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;
                Console.WriteLine("\t" + mensagem);
                Console.ResetColor();
            }

            static void ApresentaMensagemEntradaDeDados(string msg, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;
                Console.Write(msg);
                Console.ResetColor();

            }

            static void ImprimeLinhaEmBranco()
            {
                Console.WriteLine();
            }

            static void TituloMenu()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t Gestão de Equipamentos - Menu ");
                Console.ResetColor();
            }

            static void TituloSecao(string titulo)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t" + titulo + "\n");
                Console.ResetColor();
            }

            static void NomeInput(string nome)
            {
                Console.Write("\t" + nome + " ");
            }

            static void NomeCampo(string nome)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(nome);
                Console.ResetColor();
            }
            #endregion
        }
    }
}



