-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Máquina: localhost
-- Data de Criação: 06-Maio-2017 às 01:41
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
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `visibilidade` varchar(25) NOT NULL,
  `importancia` varchar(20) NOT NULL,
  `data` varchar(10) NOT NULL,
  `hora` varchar(10) NOT NULL,
  `observacoes` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Extraindo dados da tabela `agenda`
--

INSERT INTO `agenda` (`id`, `nome`, `visibilidade`, `importancia`, `data`, `hora`, `observacoes`) VALUES
(1, 'JONAS FERREIRA FERNANDES PINTO', 'Apenas eu posso ver', 'Muito Importante', '24/4/2017', '22:45:00', 'Leonardo é gay');

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `rg` varchar(15) NOT NULL,
  `cpf` varchar(15) NOT NULL,
  `dataNasc` varchar(15) NOT NULL,
  `celular` varchar(15) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `cep` varchar(15) NOT NULL,
  `uf` varchar(3) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `numeroRua` varchar(10) NOT NULL,
  `bairro` varchar(20) NOT NULL,
  `complemento` varchar(25) NOT NULL,
  `observacoes` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`id`, `nome`, `rg`, `cpf`, `dataNasc`, `celular`, `telefone`, `email`, `cep`, `uf`, `cidade`, `rua`, `numeroRua`, `bairro`, `complemento`, `observacoes`) VALUES
(1, '', '.   .   -', '.   .   -', '5/5/2017', '(  )     -', '(  )    -', '', '08543-350', 'RJ', '', '', '', '', '', ''),
(2, 'Teste', '05.156.145-6', '564.645.464-64', '5/5/2017', '(21)31231-2312', '(12)3213-1232', 'eeaase', '08543-350', 'SP', 'Ferraz de Vasconcelos', 'Manoel de Abreu', '324', 'Vila Santa Margarida', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedor`
--

CREATE TABLE IF NOT EXISTS `fornecedor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` varchar(20) NOT NULL,
  `segmento` varchar(30) DEFAULT NULL,
  `nomeCompleto` varchar(60) NOT NULL,
  `nomeFantasia` varchar(60) NOT NULL,
  `email` varchar(40) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `numeroRua` varchar(10) NOT NULL,
  `bairro` varchar(25) NOT NULL,
  `cidade` varchar(20) NOT NULL,
  `UF` varchar(4) NOT NULL,
  `CEP` varchar(16) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `telefone_2` varchar(20) DEFAULT NULL,
  `celular` varchar(20) DEFAULT NULL,
  `celular_2` varchar(20) DEFAULT NULL,
  `complemento` varchar(30) DEFAULT NULL,
  `nomeRepresentante` varchar(30) DEFAULT NULL,
  `emailRepresentante` varchar(40) DEFAULT NULL,
  `CNPJ` varchar(25) NOT NULL,
  `IE` varchar(30) DEFAULT NULL,
  `observacoes` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `fornecedor`
--

INSERT INTO `fornecedor` (`id`, `dataCadastro`, `segmento`, `nomeCompleto`, `nomeFantasia`, `email`, `rua`, `numeroRua`, `bairro`, `cidade`, `UF`, `CEP`, `telefone`, `telefone_2`, `celular`, `celular_2`, `complemento`, `nomeRepresentante`, `emailRepresentante`, `CNPJ`, `IE`, `observacoes`) VALUES
(1, '04/05/2017', 'PRESTADOR DE SERVIÇOS', 'nome fornecedor', 'nome fantasia', 'email@email', 'rua raul rual', '', 'bairrro', 'cidade', 'XF', '23432432', '3243243242', '3243243242', '34324324324', '34324343423', 'complemento', 'nome rep', 'email@rep', '34243243242342', '3432423', 'observacoes gerais sobre o fonrecedor'),
(2, '4/5/2017', '', 'Teste', '', '', 'do Rosário', 'do Rosário', 'Vila Santa Margarida', 'Ferraz de Vasconcelo', 'SP', '08543-360', ' (__) ____ - ____', ' (__) ____ - ____', ' (__) _____ - ____', ' (__) _____ - ____', '', '', '', '  __.___.___/____-__', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE IF NOT EXISTS `produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeProduto` varchar(40) NOT NULL,
  `unidadeProduto` varchar(10) DEFAULT NULL,
  `marcaProduto` varchar(20) DEFAULT NULL,
  `categoriaProduto` varchar(30) NOT NULL,
  `fornecedorProduto` varchar(50) NOT NULL,
  `valorCustoProduto` int(11) NOT NULL,
  `valorVendaProduto` int(11) NOT NULL,
  `frete` int(11) DEFAULT NULL,
  `observacoesProduto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(30) NOT NULL,
  `senha` varchar(20) NOT NULL,
  `nome` varchar(60) NOT NULL,
  `rg` varchar(15) NOT NULL,
  `tipo` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`id`, `usuario`, `senha`, `nome`, `rg`, `tipo`, `email`) VALUES
(1, 'root', '', 'NomeUsuario', '', '', ''),
(2, 'leocarinhoso', 'leoleo29', 'Leonardo Carinhoso', '51.516.516-5', 'Vendedor', 'thejonas258@gmail.com');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
