-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Máquina: localhost
-- Data de Criação: 08-Jun-2017 às 23:50
-- Versão do servidor: 5.6.12-log
-- versão do PHP: 5.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de Dados: `bd_commanager`
--
CREATE DATABASE IF NOT EXISTS `bd_commanager` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `bd_commanager`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `agenda`
--

CREATE TABLE IF NOT EXISTS `agenda` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Lembrete` varchar(50) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Importancia` varchar(40) NOT NULL,
  `Data` date NOT NULL,
  `Hora` varchar(10) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Extraindo dados da tabela `agenda`
--

INSERT INTO `agenda` (`Id`, `Lembrete`, `Nome`, `Importancia`, `Data`, `Hora`, `Observacoes`) VALUES
(1, 'asdsadsa', 'JOÃO VITOR CARDOSO CAMARGO', 'Apenas eu posso ver', '2017-05-24', '22:25:28', 'asdsadsa'),
(2, 'asdsadasdsa', 'CAIO EDUARDO', 'Todos funcionarios', '2017-05-24', '22:29:52', 'asdsadas'),
(3, 'lembrete', '', 'Todos funcionarios', '2017-05-27', '14:23:51', 'descrição');

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE IF NOT EXISTS `cliente` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(60) NOT NULL,
  `RG` varchar(15) NOT NULL,
  `CPF` varchar(15) NOT NULL,
  `DataNascimento` varchar(15) NOT NULL,
  `Celular` varchar(15) NOT NULL,
  `Telefone` varchar(15) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `CEP` varchar(15) NOT NULL,
  `UF` varchar(3) NOT NULL,
  `Cidade` varchar(25) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `Numero` int(6) NOT NULL,
  `Bairro` varchar(30) NOT NULL,
  `Complemento` varchar(40) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`Id`, `Nome`, `RG`, `CPF`, `DataNascimento`, `Celular`, `Telefone`, `Email`, `CEP`, `UF`, `Cidade`, `Rua`, `Numero`, `Bairro`, `Complemento`, `Observacoes`) VALUES
(1, 'leonardo', '11.111.111-1', '111.111.111-11', '24/5/2017', '(11)11111-1111', '(11)1111-1111', 'ashdvsagdvgh', '08557-100', 'SP', 'poa', 'asbdhasbjh', 0, 'ashdbsahj', 'sadb', 'asdsas'),
(2, 'caio', '22.222.222-2', '222.222.222-22', '24/5/2017', '(22)22222-2222', '(22)2222-2222', 'sdassda', '55555-555', 'SP', 'sadsad', 'sadsad s', 12, 's dsa dnba', 'sbdhsabdb', 'ajsndjkasbhaj'),
(4, 'Fernando', '23.432.443-2', '324.234.423-43', '27/05/2017', '(23)43243-2432', '(23)4423-4324', 'fernando@email.com', '08543-310', 'SP', 'Ferraz de Vasconcelos', 'das Acácias', 322, 'Vila Santa Margarida', '', 'perto da igreja');

-- --------------------------------------------------------

--
-- Estrutura da tabela `despesas`
--

CREATE TABLE IF NOT EXISTS `despesas` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `DataVencimento` date NOT NULL,
  `NomeDespesa` varchar(50) NOT NULL,
  `Valor` int(10) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Extraindo dados da tabela `despesas`
--

INSERT INTO `despesas` (`Id`, `DataVencimento`, `NomeDespesa`, `Valor`, `Observacoes`) VALUES
(1, '2017-05-24', 'sadasd', 2000, 'asdasda');

-- --------------------------------------------------------

--
-- Estrutura da tabela `financasfuncionarios`
--

CREATE TABLE IF NOT EXISTS `financasfuncionarios` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `ValorSalario` int(10) NOT NULL,
  `DataPagamento` date NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Extraindo dados da tabela `financasfuncionarios`
--

INSERT INTO `financasfuncionarios` (`Id`, `Nome`, `ValorSalario`, `DataPagamento`, `Observacoes`) VALUES
(1, 'sadsadas', 2000, '2017-05-24', 'asdsada');

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedor`
--

CREATE TABLE IF NOT EXISTS `fornecedor` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DataCadastro` varchar(15) NOT NULL,
  `Segmento` varchar(50) NOT NULL,
  `NomeCompleto` varchar(50) NOT NULL,
  `NomeFantasia` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `NumeroRua` varchar(5) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Cidade` varchar(50) NOT NULL,
  `UF` varchar(2) NOT NULL,
  `CEP` varchar(15) NOT NULL,
  `Telefone` varchar(20) NOT NULL,
  `Telefone2` varchar(20) NOT NULL,
  `Celular` varchar(20) NOT NULL,
  `Celular2` varchar(20) NOT NULL,
  `Complemento` varchar(15) NOT NULL,
  `NomeRepresentante` varchar(50) NOT NULL,
  `EmailRepresentante` varchar(50) NOT NULL,
  `CNPJ` varchar(15) NOT NULL,
  `IE` varchar(15) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `fornecedor`
--

INSERT INTO `fornecedor` (`Id`, `DataCadastro`, `Segmento`, `NomeCompleto`, `NomeFantasia`, `Email`, `Rua`, `NumeroRua`, `Bairro`, `Cidade`, `UF`, `CEP`, `Telefone`, `Telefone2`, `Celular`, `Celular2`, `Complemento`, `NomeRepresentante`, `EmailRepresentante`, `CNPJ`, `IE`, `Observacoes`) VALUES
(2, '4/5/2017', 'Fornecedor de Produtos', '3M Company', '3M', 'email3m@3m.com', '', '', '', '', '', '_____-___', ' (__) ____ - ____', ' (__) ____ - ____', ' (__) _____ - ____', ' (__) _____ - ____', '', 'Claudio', 'claudio@3m.com', '  45.985.371/00', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionario`
--

CREATE TABLE IF NOT EXISTS `funcionario` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `RG` varchar(15) NOT NULL,
  `CPF` varchar(15) NOT NULL,
  `DataNascimento` varchar(15) NOT NULL,
  `Celular` varchar(15) NOT NULL,
  `Telefone` varchar(15) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `UF` varchar(4) NOT NULL,
  `CEP` varchar(15) NOT NULL,
  `Cidade` varchar(40) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `NumeroRua` varchar(10) NOT NULL,
  `Bairro` varchar(30) NOT NULL,
  `Complemento` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

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

CREATE TABLE IF NOT EXISTS `orcamentos` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Cliente` varchar(50) NOT NULL,
  `Vendedor` varchar(50) NOT NULL,
  `ValorItens` int(10) NOT NULL,
  `Desconto` int(10) NOT NULL,
  `ValorFrete` int(10) NOT NULL,
  `ValorTotal` int(10) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `orcamentos`
--

INSERT INTO `orcamentos` (`Id`, `Cliente`, `Vendedor`, `ValorItens`, `Desconto`, `ValorFrete`, `ValorTotal`) VALUES
(2, 'leonardo', 'leonardo', 40, 0, 20, 60),
(3, 'jonas', 'joao', 55, 0, 30, 85),
(4, 'Bruno', 'jonas', 90, 0, 16, 106);

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE IF NOT EXISTS `produto` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Unidade` varchar(20) NOT NULL,
  `Marca` varchar(40) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Fornecedor` varchar(40) NOT NULL,
  `ValorCusto` int(10) NOT NULL,
  `ValorVenda` int(10) NOT NULL,
  `ValorFrete` int(10) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `Nome`, `Unidade`, `Marca`, `Categoria`, `Fornecedor`, `ValorCusto`, `ValorVenda`, `ValorFrete`, `Observacoes`) VALUES
(1, 'vidro', 'Unidade', 'vetro', 'vidro', '', 15, 35, 10, ''),
(3, 'Ferro 3.3mm', '', 'Trax', 'Ferro', '', 50, 130, 30, ''),
(4, 'Aluminio 5.0mm', 'Metro', 'Alz', 'Fero', '', 20, 70, 23, ''),
(5, 'Corda', 'Metro', '3M', 'Cordas', '', 0, 25, 14, ''),
(6, 'Adesivos', 'Unidade', '3M', 'Adesivos', '', 0, 0, 0, ''),
(7, 'Martelo', 'Unidade', 'Variadas', 'Ferramentas', '', 20, 35, 5, ''),
(16, 'Cooler', 'Unidade', 'Cooler Master', 'PC', '', 20, 35, 20, ''),
(17, 'Alicate de clipagem', 'Unidade', '3M', 'Ferramentas', '', 35, 55, 11, '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtosorcamentos`
--

CREATE TABLE IF NOT EXISTS `produtosorcamentos` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `IdProduto` int(10) NOT NULL,
  `IdOrcamento` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `UnidadeMedida` varchar(30) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Valor` int(10) NOT NULL,
  `ValorCusto` int(10) NOT NULL,
  `Frete` int(10) NOT NULL,
  `Observacoes` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`),
  KEY `IdProduto` (`IdProduto`),
  KEY `IdOrcamento` (`IdOrcamento`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=28 ;

--
-- Extraindo dados da tabela `produtosorcamentos`
--

INSERT INTO `produtosorcamentos` (`Id`, `IdProduto`, `IdOrcamento`, `Nome`, `UnidadeMedida`, `Marca`, `Categoria`, `Valor`, `ValorCusto`, `Frete`, `Observacoes`) VALUES
(5, 1, 2, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa'),
(6, 1, 2, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa'),
(8, 1, 3, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa'),
(20, 7, 4, 'Martelo', 'Unidade', 'Variadas', 'Ferramentas', 35, 20, 5, ''),
(23, 7, 4, 'Martelo', 'Unidade', 'Variadas', 'Ferramentas', 35, 20, 5, ''),
(24, 16, 4, 'Cooler', 'Unidade', 'Cooler Master', 'PC', 35, 20, 20, ''),
(27, 16, 3, 'Cooler', 'Unidade', 'Cooler Master', 'PC', 35, 20, 20, '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtosvendas`
--

CREATE TABLE IF NOT EXISTS `produtosvendas` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `IdProduto` int(10) NOT NULL,
  `IdVenda` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `UnidadeMedida` varchar(30) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Valor` int(10) NOT NULL COMMENT 'R$00,00',
  `ValorCusto` int(10) NOT NULL,
  `Frete` int(10) NOT NULL,
  `Observacoes` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdProduto` (`IdProduto`),
  KEY `IdVenda` (`IdVenda`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Extraindo dados da tabela `produtosvendas`
--

INSERT INTO `produtosvendas` (`Id`, `IdProduto`, `IdVenda`, `Nome`, `UnidadeMedida`, `Marca`, `Categoria`, `Valor`, `ValorCusto`, `Frete`, `Observacoes`) VALUES
(2, 1, 2, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa'),
(3, 1, 3, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa'),
(4, 1, 3, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa'),
(6, 1, 4, 'vidro', 'Unidade', 'vetro', 'vidro', 20, 15, 10, 'sagvdgsa');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtosvendastemporaria`
--

CREATE TABLE IF NOT EXISTS `produtosvendastemporaria` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `IdProduto` int(10) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `UnidadeMedida` varchar(20) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Valor` int(10) NOT NULL,
  `ValorCusto` int(10) NOT NULL,
  `Frete` int(10) NOT NULL,
  `Observacoes` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`),
  KEY `IdProduto` (`IdProduto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(50) NOT NULL,
  `Senha` varchar(50) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `RG` varchar(15) NOT NULL,
  `Tipo` varchar(25) NOT NULL,
  `Email` varchar(60) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Usuario`, `Senha`, `Nome`, `RG`, `Tipo`, `Email`) VALUES
(1, 'root', 'root', 'Root', '0', 'Avançado', '0'),
(3, 'vendedor', 'root', 'Vendedor', '12.345.678-9', 'Vendedor', 'vendedor@vendedor.com');

-- --------------------------------------------------------

--
-- Estrutura da tabela `vendas`
--

CREATE TABLE IF NOT EXISTS `vendas` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `IdComprador` int(10) NOT NULL,
  `IdVendedor` int(10) NOT NULL,
  `Comprador` varchar(50) NOT NULL,
  `Vendedor` varchar(50) NOT NULL,
  `DataVenda` date NOT NULL,
  `HoraVenda` varchar(15) NOT NULL,
  `DataEntrega` varchar(15) NOT NULL,
  `HoraEntrega` varchar(15) NOT NULL,
  `Observacoes` varchar(60) NOT NULL,
  `ValorItens` int(10) NOT NULL,
  `Desconto` int(10) NOT NULL,
  `ValorFrete` int(10) NOT NULL,
  `ValorTotal` int(10) NOT NULL,
  `ValorLucro` int(10) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`),
  KEY `IdComprador` (`IdComprador`),
  KEY `IdVendedor` (`IdVendedor`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `vendas`
--

INSERT INTO `vendas` (`Id`, `IdComprador`, `IdVendedor`, `Comprador`, `Vendedor`, `DataVenda`, `HoraVenda`, `DataEntrega`, `HoraEntrega`, `Observacoes`, `ValorItens`, `Desconto`, `ValorFrete`, `ValorTotal`, `ValorLucro`) VALUES
(2, 2, 2, 'caio', 'joao', '2017-05-24', '22:16:19', '10/6/2000', '22:16:19', 'xfdxdffd', 20, 0, 10, 30, 0),
(3, 2, 2, 'caio', 'jonas', '2017-05-26', '19:27:03', '26/5/2017', '19:27:03', 'asasdsasd', 40, 0, 20, 60, 0),
(4, 1, 2, 'leonardo', 'leonardo', '2017-05-26', '19:30:39', '26/5/2017', '19:30:39', 'sadsad', 20, 0, 10, 30, 0);

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `produtosorcamentos`
--
ALTER TABLE `produtosorcamentos`
  ADD CONSTRAINT `produtosorcamentos_ibfk_2` FOREIGN KEY (`IdOrcamento`) REFERENCES `orcamentos` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `produtosorcamentos_ibfk_1` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

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
