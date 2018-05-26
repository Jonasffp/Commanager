-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 26-Jun-2017 às 05:50
-- Versão do servidor: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bd_commanager`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `agenda`
--

CREATE TABLE `agenda` (
  `Id` int(10) NOT NULL,
  `Lembrete` varchar(50) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Importancia` varchar(40) NOT NULL,
  `Data` date NOT NULL,
  `Hora` varchar(20) NOT NULL,
  `Observacoes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `agenda`
--

INSERT INTO `agenda` (`Id`, `Lembrete`, `Nome`, `Importancia`, `Data`, `Hora`, `Observacoes`) VALUES
(1, 'asdsadsa', 'JOÃO VITOR CARDOSO CAMARGO', 'Apenas eu posso ver', '2017-05-24', '22:25:28', 'asdsadsa'),
(2, 'asdsadasdsa', 'CAIO EDUARDO', 'Todos funcionarios', '2017-05-24', '22:29:52', 'asdsadas'),
(3, 'lembrete', 'Jonas Ferreira', 'Normal', '2017-06-25', '20:25:53', 'descrição');

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE `cliente` (
  `Id` int(10) NOT NULL,
  `Nome` varchar(60) NOT NULL,
  `RG` varchar(30) NOT NULL,
  `CPF` varchar(30) NOT NULL,
  `DataNascimento` varchar(30) NOT NULL,
  `Celular` varchar(20) NOT NULL,
  `Telefone` varchar(20) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `CEP` varchar(30) NOT NULL,
  `UF` varchar(3) NOT NULL,
  `Cidade` varchar(25) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `Numero` varchar(10) NOT NULL,
  `Bairro` varchar(40) NOT NULL,
  `Complemento` varchar(40) NOT NULL,
  `Observacoes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`Id`, `Nome`, `RG`, `CPF`, `DataNascimento`, `Celular`, `Telefone`, `Email`, `CEP`, `UF`, `Cidade`, `Rua`, `Numero`, `Bairro`, `Complemento`, `Observacoes`) VALUES
(1, 'leonardo', '11.111.111-1', '111.111.111-11', '24/5/2017', '(11)11111-1111', '(11)1111-1111', 'ashdvsagdvgh', '08557-100', 'SP', 'poa', 'asbdhasbjh', '0', 'ashdbsahj', 'sadb', 'asdsas'),
(2, 'caio', '22.222.222-2', '222.222.222-22', '24/5/2017', '(22)22222-2222', '(22)2222-2222', 'sdassda', '55555-555', 'SP', 'sadsad', 'sadsad s', '12', 's dsa dnba', 'sbdhsabdb', 'ajsndjkasbhaj'),
(4, 'Fernando', '23.432.443-2', '324.234.423-43', '27/05/2017', '(23)43243-2432', '(23)4423-4324', 'fernando@email.com', '08543-310', 'SP', 'Ferraz de Vasconcelos', 'das Acácias', '322', 'Vila Santa Margarida', '', 'perto da igreja');

-- --------------------------------------------------------

--
-- Estrutura da tabela `despesas`
--

CREATE TABLE `despesas` (
  `Id` int(10) NOT NULL,
  `DataVencimento` date NOT NULL,
  `NomeDespesa` varchar(50) NOT NULL,
  `Valor` decimal(10,2) NOT NULL,
  `Observacoes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `despesas`
--

INSERT INTO `despesas` (`Id`, `DataVencimento`, `NomeDespesa`, `Valor`, `Observacoes`) VALUES
(1, '2017-05-24', 'sadasd', '2000.56', 'asdasda');

-- --------------------------------------------------------

--
-- Estrutura da tabela `financasfuncionarios`
--

CREATE TABLE `financasfuncionarios` (
  `Id` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `ValorSalario` decimal(10,2) NOT NULL,
  `DataPagamento` date NOT NULL,
  `Observacoes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `financasfuncionarios`
--

INSERT INTO `financasfuncionarios` (`Id`, `Nome`, `ValorSalario`, `DataPagamento`, `Observacoes`) VALUES
(2, 'Jonas Ferreira', '1250.50', '2017-06-26', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedor`
--

CREATE TABLE `fornecedor` (
  `Id` int(11) NOT NULL,
  `DataCadastro` varchar(15) NOT NULL,
  `Segmento` varchar(50) NOT NULL,
  `NomeCompleto` varchar(50) NOT NULL,
  `NomeFantasia` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `NumeroRua` varchar(15) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Cidade` varchar(50) NOT NULL,
  `UF` varchar(5) NOT NULL,
  `CEP` varchar(30) NOT NULL,
  `Telefone` varchar(20) NOT NULL,
  `Telefone2` varchar(20) NOT NULL,
  `Celular` varchar(20) NOT NULL,
  `Celular2` varchar(20) NOT NULL,
  `Complemento` varchar(30) NOT NULL,
  `NomeRepresentante` varchar(50) NOT NULL,
  `EmailRepresentante` varchar(50) NOT NULL,
  `CNPJ` varchar(30) NOT NULL,
  `IE` varchar(15) NOT NULL,
  `Observacoes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `fornecedor`
--

INSERT INTO `fornecedor` (`Id`, `DataCadastro`, `Segmento`, `NomeCompleto`, `NomeFantasia`, `Email`, `Rua`, `NumeroRua`, `Bairro`, `Cidade`, `UF`, `CEP`, `Telefone`, `Telefone2`, `Celular`, `Celular2`, `Complemento`, `NomeRepresentante`, `EmailRepresentante`, `CNPJ`, `IE`, `Observacoes`) VALUES
(2, '4/5/2017', 'Fornecedor de Produtos', '3M Company', '3M', 'email3m@3m.com', '', '', '', '', '', '_____-___', ' (__) ____ - ____', ' (__) ____ - ____', ' (__) _____ - ____', ' (__) _____ - ____', '', 'Claudio', 'claudio@3m.com', '  45.985.371/00', '', ''),
(3, '04/05/2017', 'Advogado', 'ex', 'Exemplo', 'asd', '', '', '', '', '', '_____-___', ' (__) ____ - ____', ' (__) ____ - ____', ' (__) _____ - ____', ' (__) _____ - ____', '', 'asd', 'sadasd', '  __.___.___/____-__', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionario`
--

CREATE TABLE `funcionario` (
  `Id` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `RG` varchar(30) NOT NULL,
  `CPF` varchar(30) NOT NULL,
  `DataNascimento` varchar(20) NOT NULL,
  `Celular` varchar(20) NOT NULL,
  `Telefone` varchar(20) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `UF` varchar(4) NOT NULL,
  `CEP` varchar(30) NOT NULL,
  `Cidade` varchar(40) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `NumeroRua` varchar(10) NOT NULL,
  `Bairro` varchar(40) NOT NULL,
  `Complemento` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `funcionario`
--

INSERT INTO `funcionario` (`Id`, `Nome`, `RG`, `CPF`, `DataNascimento`, `Celular`, `Telefone`, `Email`, `UF`, `CEP`, `Cidade`, `Rua`, `NumeroRua`, `Bairro`, `Complemento`) VALUES
(1, 'Leonardo Vinicius', '11.111.111-1', '222.222.222-22', '25/5/2017', '(10)22222-2222', '(11)1111-1111', 'asdbghsadjh', 'SP', '15654-646', 'ashdbah', 'vgasvdhga', '12', 'dasdbj', 'asvdgsah'),
(2, 'João Vitor', '22.222.222-2', '111.111.111-11', '25/5/2017', '(21)32165-4651', '(56)4654-6546', 'joao@email.com', 'SP', '31545-646', 'sbdasjh', 'kdbahsagsvh', '445', 'ashdbsajhv', 'ahsbd'),
(3, 'Jonas Ferreira', '15.346.563-4', '546.546.54 -', '15/4/2000', '(41)54656-', '(64)6546-54', 'jonas@email.com', 'SP', '23432-424', 'Ferraz de Vasconcelos', 'Rua Ale', '222', 'Ale', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `orcamentos`
--

CREATE TABLE `orcamentos` (
  `Id` int(10) NOT NULL,
  `Cliente` varchar(50) NOT NULL,
  `Vendedor` varchar(50) NOT NULL,
  `ValorItens` decimal(10,2) NOT NULL,
  `Desconto` decimal(10,2) NOT NULL,
  `ValorFrete` decimal(10,2) NOT NULL,
  `ValorTotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `orcamentos`
--

INSERT INTO `orcamentos` (`Id`, `Cliente`, `Vendedor`, `ValorItens`, `Desconto`, `ValorFrete`, `ValorTotal`) VALUES
(2, 'leonardo', 'leonardo', '40.00', '0.00', '20.00', '60.00'),
(3, 'jonas', 'joao', '55.00', '0.00', '30.00', '85.00'),
(4, 'Bruno', 'jonas', '90.00', '0.00', '16.00', '106.00'),
(5, 'Exemplo', 'Jonas Ferreira', '16.99', '0.00', '17.88', '34.87');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Unidade` varchar(20) NOT NULL,
  `Marca` varchar(40) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Fornecedor` varchar(40) NOT NULL,
  `ValorCusto` decimal(10,2) NOT NULL,
  `ValorVenda` decimal(10,2) NOT NULL,
  `ValorFrete` decimal(10,2) NOT NULL,
  `Observacoes` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `Nome`, `Unidade`, `Marca`, `Categoria`, `Fornecedor`, `ValorCusto`, `ValorVenda`, `ValorFrete`, `Observacoes`) VALUES
(1, 'vidro', 'Unidade', 'vetro', 'vidro', '', '15.00', '35.00', '10.00', ''),
(3, 'Ferro 3.3mm', '', 'Trax', 'Ferro', '', '50.00', '130.00', '30.00', ''),
(4, 'Aluminio 5.0mm', 'Metro', 'Alz', 'Fero', '', '20.00', '70.00', '23.00', ''),
(6, 'Adesivos', 'Unidade', '3M', 'Adesivos', '', '0.00', '0.00', '0.00', ''),
(7, 'Martelo', 'Unidade', 'Variadas', 'Ferramentas', '3M', '20.00', '35.00', '5.00', ''),
(16, 'Cooler', 'Unidade', 'Cooler Master', 'PC', '', '20.00', '35.00', '20.00', ''),
(17, 'Alicate de clipagem', 'Unidade', '3M', 'Ferramentas', '', '35.00', '55.00', '11.00', ''),
(18, 'Fita Isolante', 'Unidade', '3m', 'Construção', '3M', '5.60', '16.99', '7.45', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtosorcamentos`
--

CREATE TABLE `produtosorcamentos` (
  `Id` int(10) NOT NULL,
  `IdProduto` int(10) NOT NULL,
  `IdOrcamento` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `UnidadeMedida` varchar(30) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Valor` decimal(10,2) NOT NULL,
  `ValorCusto` decimal(10,2) NOT NULL,
  `Frete` decimal(10,2) NOT NULL,
  `Observacoes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produtosorcamentos`
--

INSERT INTO `produtosorcamentos` (`Id`, `IdProduto`, `IdOrcamento`, `Nome`, `UnidadeMedida`, `Marca`, `Categoria`, `Valor`, `ValorCusto`, `Frete`, `Observacoes`) VALUES
(5, 1, 2, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(6, 1, 2, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(8, 1, 3, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(20, 7, 4, 'Martelo', 'Unidade', 'Variadas', 'Ferramentas', '35.00', '20.00', '5.00', ''),
(23, 7, 4, 'Martelo', 'Unidade', 'Variadas', 'Ferramentas', '35.00', '20.00', '5.00', ''),
(24, 16, 4, 'Cooler', 'Unidade', 'Cooler Master', 'PC', '35.00', '20.00', '20.00', ''),
(27, 16, 3, 'Cooler', 'Unidade', 'Cooler Master', 'PC', '35.00', '20.00', '20.00', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtosvendas`
--

CREATE TABLE `produtosvendas` (
  `Id` int(10) NOT NULL,
  `IdProduto` int(10) NOT NULL,
  `IdVenda` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `UnidadeMedida` varchar(30) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Valor` decimal(10,2) NOT NULL COMMENT 'R$00,00',
  `ValorCusto` decimal(10,2) NOT NULL,
  `Frete` decimal(10,2) NOT NULL,
  `Observacoes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produtosvendas`
--

INSERT INTO `produtosvendas` (`Id`, `IdProduto`, `IdVenda`, `Nome`, `UnidadeMedida`, `Marca`, `Categoria`, `Valor`, `ValorCusto`, `Frete`, `Observacoes`) VALUES
(2, 1, 2, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(3, 1, 3, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(4, 1, 3, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(6, 1, 4, 'vidro', 'Unidade', 'vetro', 'vidro', '20.00', '15.00', '10.00', 'sagvdgsa'),
(7, 17, 5, 'Alicate de clipagem', 'Unidade', '3M', 'Ferramentas', '55.00', '35.00', '11.00', ''),
(8, 18, 6, 'Fita Isolante', 'Unidade', '3m', 'Construção', '16.99', '5.60', '7.45', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtosvendastemporaria`
--

CREATE TABLE `produtosvendastemporaria` (
  `Id` int(10) NOT NULL,
  `IdProduto` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `UnidadeMedida` varchar(20) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Valor` decimal(10,2) NOT NULL,
  `ValorCusto` decimal(10,2) NOT NULL,
  `Frete` decimal(10,2) NOT NULL,
  `Observacoes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Senha` varchar(50) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `RG` varchar(15) NOT NULL,
  `Tipo` varchar(25) NOT NULL,
  `Email` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Usuario`, `Senha`, `Nome`, `RG`, `Tipo`, `Email`) VALUES
(1, 'root', 'root', 'Nome do usuário', '0', 'Avançado', '0'),
(3, 'vendedor', 'root', 'Vendedor', '12.345.678-9', 'Vendedor', 'vendedor@vendedor.com');

-- --------------------------------------------------------

--
-- Estrutura da tabela `vendas`
--

CREATE TABLE `vendas` (
  `Id` int(10) NOT NULL,
  `IdComprador` int(10) NOT NULL,
  `IdVendedor` int(10) NOT NULL,
  `Comprador` varchar(50) NOT NULL,
  `Vendedor` varchar(50) NOT NULL,
  `DataVenda` date NOT NULL,
  `HoraVenda` varchar(15) NOT NULL,
  `DataEntrega` varchar(15) NOT NULL,
  `HoraEntrega` varchar(15) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  `ValorItens` decimal(10,2) NOT NULL,
  `Desconto` decimal(10,2) NOT NULL,
  `ValorFrete` decimal(10,2) NOT NULL,
  `ValorTotal` decimal(10,2) NOT NULL,
  `ValorLucro` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `vendas`
--

INSERT INTO `vendas` (`Id`, `IdComprador`, `IdVendedor`, `Comprador`, `Vendedor`, `DataVenda`, `HoraVenda`, `DataEntrega`, `HoraEntrega`, `Observacoes`, `ValorItens`, `Desconto`, `ValorFrete`, `ValorTotal`, `ValorLucro`) VALUES
(2, 2, 0, 'caio', 'Jonas Ferreira', '2017-05-24', '22:16:19', '10/06/2000', '22:16:19', 'xfdxdffd', '20.00', '0.00', '10.00', '30.00', '0.00'),
(3, 2, 2, 'caio', 'João Vitor', '2017-05-26', '19:27:03', '26/05/2017', '19:27:03', 'asasdsasd', '40.00', '0.00', '20.00', '60.00', '0.00'),
(4, 1, 2, 'leonardo', 'Leonardo Vinicius', '2017-05-26', '19:30:39', '26/05/2017', '19:30:39', 'sadsad', '20.00', '0.00', '10.00', '30.00', '0.00'),
(5, 4, 0, 'Fernando', 'Jonas Ferreira', '2017-06-25', '22:09:19', '25/06/2017', '22:09:19', '', '72.00', '0.88', '0.00', '71.12', '31.00'),
(6, 1, 0, 'leonardo', 'Jonas Ferreira', '2017-06-26', '02:18:48', '26/06/2017', '02:18:48', '', '71.99', '10.44', '18.45', '80.00', '31.39');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agenda`
--
ALTER TABLE `agenda`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id` (`Id`);

--
-- Indexes for table `despesas`
--
ALTER TABLE `despesas`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `financasfuncionarios`
--
ALTER TABLE `financasfuncionarios`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `fornecedor`
--
ALTER TABLE `fornecedor`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `funcionario`
--
ALTER TABLE `funcionario`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `orcamentos`
--
ALTER TABLE `orcamentos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id` (`Id`);

--
-- Indexes for table `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id` (`Id`);

--
-- Indexes for table `produtosorcamentos`
--
ALTER TABLE `produtosorcamentos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id` (`Id`),
  ADD KEY `IdProduto` (`IdProduto`),
  ADD KEY `IdOrcamento` (`IdOrcamento`);

--
-- Indexes for table `produtosvendas`
--
ALTER TABLE `produtosvendas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdProduto` (`IdProduto`),
  ADD KEY `IdVenda` (`IdVenda`);

--
-- Indexes for table `produtosvendastemporaria`
--
ALTER TABLE `produtosvendastemporaria`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id` (`Id`),
  ADD KEY `IdProduto` (`IdProduto`);

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `vendas`
--
ALTER TABLE `vendas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id` (`Id`),
  ADD KEY `IdComprador` (`IdComprador`),
  ADD KEY `IdVendedor` (`IdVendedor`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agenda`
--
ALTER TABLE `agenda`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `cliente`
--
ALTER TABLE `cliente`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `despesas`
--
ALTER TABLE `despesas`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `financasfuncionarios`
--
ALTER TABLE `financasfuncionarios`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `fornecedor`
--
ALTER TABLE `fornecedor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `funcionario`
--
ALTER TABLE `funcionario`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `orcamentos`
--
ALTER TABLE `orcamentos`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `produto`
--
ALTER TABLE `produto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT for table `produtosorcamentos`
--
ALTER TABLE `produtosorcamentos`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
--
-- AUTO_INCREMENT for table `produtosvendas`
--
ALTER TABLE `produtosvendas`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `produtosvendastemporaria`
--
ALTER TABLE `produtosvendastemporaria`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `vendas`
--
ALTER TABLE `vendas`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `produtosorcamentos`
--
ALTER TABLE `produtosorcamentos`
  ADD CONSTRAINT `produtosorcamentos_ibfk_1` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `produtosorcamentos_ibfk_2` FOREIGN KEY (`IdOrcamento`) REFERENCES `orcamentos` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limitadores para a tabela `produtosvendas`
--
ALTER TABLE `produtosvendas`
  ADD CONSTRAINT `produtosvendas_ibfk_1` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`),
  ADD CONSTRAINT `produtosvendas_ibfk_2` FOREIGN KEY (`IdVenda`) REFERENCES `vendas` (`Id`);

--
-- Limitadores para a tabela `produtosvendastemporaria`
--
ALTER TABLE `produtosvendastemporaria`
  ADD CONSTRAINT `produtosvendastemporaria_ibfk_1` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
