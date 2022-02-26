using System;

namespace ControleDeEquipamentos.ConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //variaveis
            string opcaoMenu;
            string continuar;
            string[] nomeEquipamento = new string[1000];
            string[] numeroSerie = new string[1000];
            decimal[] precoEquipamento = new decimal[1000];
            string[] dataFabricacao = new string[1000];
            string[] nomeFabricante = new string[1000];
            bool[] temChamado = new bool[1000];
            int indice = 0;
            //variaveis chamado
            int[] idChamado = new int[1000];
            string[] tituloChamado = new string[1000];
            string[] descricaoChamado = new string[1000];
            string[] dataAberturaChamado = new string[1000];
            int indiceChamado = 0;
            int geraid = 1;
            bool[] statusChamado = new bool[1000];

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
                        ExibeChamados(ref numeroSerie, ref temChamado, ref tituloChamado,
             ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "7":
                        EditaChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado);
                        break;
                    case "8":
                        ExcluiChamado(ref numeroSerie, ref temChamado, ref tituloChamado, ref descricaoChamado, ref dataAberturaChamado, ref indiceChamado, ref idChamado, ref statusChamado);
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                }


            } while (1 == 1);


            #region 
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
                //string auxChamado;

                TituloSecao("1 - Registrar Novo Equipamento");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Nome:");
                nomeEquipamento[indice] = Console.ReadLine();
                VerificaQuantidadeCaracteres(ref nomeEquipamento, ref indice);
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Número de Série:");
                numeroSerie[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Preço:");
                precoEquipamento[indice] = decimal.Parse(Console.ReadLine());
                ImprimeLinhaEmBranco();

                NomeInput("Digite a Data de Fabricação (dd/mm/aaaa):");
                dataFabricacao[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Fabricante:");
                nomeFabricante[indice] = Console.ReadLine();
                ImprimeLinhaEmBranco();

                temChamado[indice] = false;

                //NomeInput("O Equipamento possuí chamado? Digite S para sim ou N para não: ");
                //auxChamado = Console.ReadLine();
                //while (auxChamado != "S" && auxChamado != "N")
                //{
                //    ApresentaMensagem("Informe se o equipamento possuí chamado em aberto", ConsoleColor.Red);
                //    Console.Write("\tDigite S para sim ou N para não: ");
                //    auxChamado = Console.ReadLine();

                //}

                //if (auxChamado == "S")
                //{
                //    temChamado[indice] = true;

                //}
                //else if (auxChamado == "N")
                //{
                //    temChamado[indice] = false;
                //}

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
                    ApresentaMensagem("O nome do equipamento deve possuir no minimo 6 caracteres", ConsoleColor.Red);
                    NomeInput("Digite o Nome:");
                    nomeEquipamento[indice] = Console.ReadLine();
                }
            }

            static void ExibeEquipamentosRegistrados(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado, ref int indice)
            {

                TituloSecao("2 - Visualizar os Equipamentos Registrados");


                if (indice == 0)
                {

                    ApresentaMensagem("Não há equipamentos registrados. Digite qualquer tecla para retornar ao menu", ConsoleColor.Red);

                }
                else
                {
                    for (int i = 0; i < indice; i++)
                    {
                        if (numeroSerie[i] != null)
                        {
                            Console.WriteLine("____________________");
                            Console.WriteLine("Nome: " + nomeEquipamento[i]);
                            Console.WriteLine("Número de Série: " + numeroSerie[i]);
                            Console.WriteLine("Fabricante: " + nomeFabricante[i]);
                            Console.WriteLine("Tem chamado: " + temChamado[i]);
                            Console.WriteLine("____________________");
                        }


                    }
                    ApresentaMensagem("\n\tListagem de equipamentos finalizada! Digite qualquer tecla para retornar ao menu", ConsoleColor.DarkGreen);
                }
                Console.ReadLine();
            }

            static void EditaEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado)
            {
                string nomeTemp;

                TituloSecao("3 - Editar Equipamento");
                ImprimeLinhaEmBranco();


                NomeInput("Digite o Nº de Série do equipamento que deseja editar:");
                string numeroSerieEditar = Console.ReadLine();
                bool numeroSerieExiste = false;

                ImprimeLinhaEmBranco();

                for (int i = 0; i < numeroSerie.Length; i++)
                {

                    if (numeroSerieEditar == numeroSerie[i]) //quando encontrar o numeroSerie igual o digitado, apresenta os campos para editar o equip.
                    {
                        numeroSerieExiste = true;

                        ApresentaMensagem("Editando Equipamento Nº Série = " + numeroSerie[i], ConsoleColor.Blue);

                        NomeInput("Digite o novo Nome:");

                        nomeTemp = Console.ReadLine();

                        //verifica qtd caracter
                        while (nomeTemp.Length < 6)
                        {
                            ApresentaMensagem("O nome do equipamento deve possuir no minimo 6 caracteres", ConsoleColor.Red);
                            NomeInput("Digite o novo Nome:");
                            nomeTemp = Console.ReadLine();
                            continue;
                        }

                        nomeEquipamento[i] = nomeTemp;

                        ImprimeLinhaEmBranco();
                        NomeInput("Digite o novo Número de Série:");
                        numeroSerie[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Preço:");
                        precoEquipamento[i] = decimal.Parse(Console.ReadLine());
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a nova Data de Fabricação (dd/mm/aaaa):");
                        dataFabricacao[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Fabricante:");
                        nomeFabricante[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();


                        ApresentaMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);

                    }

                }
                if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não encontrado! Verifique o Número de Série e tente novamente!", ConsoleColor.Red);

                }

                Console.ReadLine();

            }

            static void ExcluiEquipamento(ref string[] nomeEquipamento, ref string[] numeroSerie, ref decimal[] precoEquipamento, ref string[] dataFabricacao, ref string[] nomeFabricante, ref bool[] temChamado)
            {
                //variaveis
                string numeroSerieSelecionado, confirmacao;
                bool numeroSerieExiste = false;

                TituloSecao("4 - Excluir Equipamento");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o número de série do equipamento que deseja excluir:");
                numeroSerieSelecionado = Console.ReadLine();

                for (int i = 0; i < numeroSerie.Length; i++)
                {
                    //não permite exclusão caso o equipamento possua chamado em aberto
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

                //caso numero de serie inexistente, apresenta mensagem
                if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não encontrado! Verifique o Número de Série e tente novamente!", ConsoleColor.Red);

                }

                Console.ReadLine();
            }

            static void RegistrarChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado,
                ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref int geraid, ref bool[] statusChamado)
            {
                string numeroSerieSelecionado;
                bool numeroSerieExiste = false;

                TituloSecao("5 - Registrar Chamado de Manutenção");
                ImprimeLinhaEmBranco();

                NomeInput("Digite o Número de Série do Equipamento:");
                numeroSerieSelecionado = Console.ReadLine();
                ImprimeLinhaEmBranco();



                for (int i = 0; i < numeroSerie.Length; i++)
                {
                    //não permite exclusão caso o equipamento possua chamado em aberto
                    if (numeroSerie[i] == numeroSerieSelecionado)
                    {

                        numeroSerieExiste = true;

                        NomeInput("Digite o Título do Chamado:");

                        tituloChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a Descrição do Chamado:");
                        descricaoChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a Data de Abertura do Chamado:");
                        dataAberturaChamado[indiceChamado] = Console.ReadLine();
                        ImprimeLinhaEmBranco();


                        idChamado[indiceChamado] = geraid;

                        temChamado[i] = true;

                        statusChamado[i] = true;

                        indiceChamado++;

                        ApresentaMensagem("Chamado registrado com sucesso!", ConsoleColor.Green);

                        geraid++;
                        Console.ReadLine();
                    }

                }
                if (numeroSerieExiste == false)
                {
                    ApresentaMensagem("Equipamento não encontrado! Verifique o Número de Série e tente novamente!", ConsoleColor.Red);
                    Console.ReadLine();
                }

            }

            static void ExibeChamados(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado,
                ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                TituloSecao("6 - Visualizar os Chamados Registrados");
                ImprimeLinhaEmBranco();

                if (indiceChamado == 0)
                {
                    ApresentaMensagem("Não há chamados registrados!", ConsoleColor.Red);
                    Console.ReadLine();

                }
                else
                {
                    for (int i = 0; i < indiceChamado; i++)
                    {
                        if (statusChamado[i] == true)
                        {
                            Console.WriteLine("____________________");
                            Console.WriteLine("ID chamado:" + idChamado[i]);
                            Console.WriteLine("Titulo Chamado: " + tituloChamado[i]);
                            Console.WriteLine("Nº Série Equipamento: " + numeroSerie[i]);
                            Console.WriteLine("Descrição do Chamado: " + descricaoChamado[i]);
                            Console.WriteLine("Data de Abertura: " + dataAberturaChamado[i]);
                            Console.WriteLine("Dias em aberto:");
                            Console.WriteLine("____________________");

                        }
                    }
                    ApresentaMensagem("\n\tListagem de chamados finalizada! Digite qualquer tecla para retornar ao menu", ConsoleColor.DarkGreen);
                }
                Console.ReadLine();

            }

            static void EditaChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado)
            {
                bool chamadoExiste = false;
                TituloSecao("7 - Editar Chamado");
                ImprimeLinhaEmBranco();
                NomeInput("Digite o indice do chamado que deseja editar:");
                int chamadoSelecionado = int.Parse(Console.ReadLine());

                for (int i = 0; i < idChamado.Length; i++)
                {

                    if (chamadoSelecionado == idChamado[i]) //quando encontrar o numeroSerie igual o digitado, apresenta os campos para editar o equip.
                    {
                        chamadoExiste = true;
                        ApresentaMensagem("Editando Chamado ID = " + idChamado[i], ConsoleColor.Blue);

                        NomeInput("Digite o Número de Série do Equipamento:");
                        numeroSerie[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite o novo Titulo do Chamado:");
                        tituloChamado[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a nova Descrição do Chamado:");
                        descricaoChamado[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        NomeInput("Digite a nova Data de Abertura do Chamado:");
                        dataAberturaChamado[i] = Console.ReadLine();
                        ImprimeLinhaEmBranco();

                        ApresentaMensagem("Chamado editado com sucesso!", ConsoleColor.Green);

                    }
                }

                if (chamadoExiste == false)
                {
                    ApresentaMensagem("Chamado não encontrado! Verifique o ID do Chamado e tente novamente!", ConsoleColor.Red);
                }
                Console.ReadLine();

            }

            static void ExcluiChamado(ref string[] numeroSerie, ref bool[] temChamado, ref string[] tituloChamado, ref string[] descricaoChamado, ref string[] dataAberturaChamado, ref int indiceChamado, ref int[] idChamado, ref bool[] statusChamado)
            {
                //variaveis
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
                            ApresentaMensagem("Deseja remover o chamado ID = " + numeroSerie[i] + "? Digite S para Confirmar ou N para cancelar", ConsoleColor.Red);
                            confirmacao = Console.ReadLine();
                            while (confirmacao != "S" && confirmacao != "N")
                            {
                                ApresentaMensagem("Opção inválida!", ConsoleColor.Red);
                                ApresentaMensagem("Deseja remover o equipamento com Nº de série " + numeroSerie[i] + "? Digite S para Confirmar ou N para cancelar: ", ConsoleColor.Red);
                                confirmacao = Console.ReadLine();
                            }
                            if (confirmacao == "S")
                            {
                                temChamado[i] = false;
                                statusChamado[i] = false;
                                ApresentaMensagem("Chamado removido com sucesso!", ConsoleColor.Green);
                            } else if(confirmacao == "N")
                            {
                                ApresentaMensagem("Operação cancelada!", ConsoleColor.Yellow);

                            }
                        }


                    }
                }

                if (idChamadoExiste == false)
                {
                    ApresentaMensagem("Chamado não encontrado! Verifique o ID do Chamado e tente novamente!", ConsoleColor.Red);
                }
                Console.ReadLine();
            }
            #endregion

            #region metodos estilizacao

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
                Console.WriteLine("\n\t" + titulo);
                Console.ResetColor();
            }

            static void NomeInput(string nome)
            {
                Console.Write("\t" + nome + " ");
            }
            #endregion
        }
    }
}



