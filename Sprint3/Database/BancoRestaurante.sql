-- 1. DESTRUIÇÃO TOTAL E RECRIAÇÃO DO SCHEMA (Reset de fábrica)
DROP DATABASE IF EXISTS restaurante;
CREATE DATABASE restaurante;
USE restaurante;

-- 2. TABELA DE CARDÁPIO (Pokémon Edition)
CREATE TABLE cardapio (
    id_cardapio INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(40) NOT NULL,
    descricao LONGTEXT,
    preco DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (id_cardapio)
) ENGINE=InnoDB;

-- 3. TABELA DE CLIENTES
CREATE TABLE cliente (
    id_cliente INT NOT NULL AUTO_INCREMENT,
    cpf VARCHAR(15) NOT NULL,
    nome VARCHAR(60) NOT NULL,
    PRIMARY KEY (id_cliente)
) ENGINE=InnoDB;

-- 4. TABELA DE FUNCIONÁRIOS (Precisa vir ANTES de Pedidos)
CREATE TABLE funcionario (
    id_funcionario INT NOT NULL AUTO_INCREMENT,
    nome LONGTEXT NOT NULL,
    cargo LONGTEXT,
    salario DECIMAL(18,2) NOT NULL,
    status LONGTEXT,
    PRIMARY KEY (id_funcionario)
) ENGINE=InnoDB;

-- 5. TABELA DE PEDIDOS (Agora pode se conectar aos Clientes e Funcionários)
CREATE TABLE pedido (
    id_pedido INT NOT NULL AUTO_INCREMENT,
    id_cliente INT NOT NULL,
    id_funcionario INT NOT NULL,
    data_pedido DATETIME DEFAULT CURRENT_TIMESTAMP,
    status_pedido VARCHAR(20) DEFAULT 'Pendente',
    PRIMARY KEY (id_pedido),
    CONSTRAINT fk_cliente_pedido FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente),
    CONSTRAINT fk_funcionario_pedido FOREIGN KEY (id_funcionario) REFERENCES funcionario(id_funcionario)
) ENGINE=InnoDB;

-- 6. POPULAR O CARDÁPIO
INSERT INTO cardapio (nome, descricao, preco) VALUES
('Applin Caramelizado', 'Maçã silvestre envolta em calda de açúcar brilhante.', 48.00),
('Torta de Appletun', 'Massa folhada recheada com néctar doce.', 68.00),
('Cozido de Pikachu', 'Guisado picante com especiarias elétricas.', 62.00),
('Magikarp Grelhado', 'Filé firme grelhado na brasa com ervas finas.', 59.00),
('Salada de Chikorita', 'Mix de folhas aromáticas frescas.', 45.00),
('Muqueca de Krabby', 'Ensopado suculento com leite de coco.', 72.00),
('Sopa de Squirtle', 'Caldo marinho refrescante com algas raras.', 88.00),
('Tempurá de Tentacool', 'Anéis crocantes fritos com molho agridoce.', 84.00),
('Espetinho de Torchic', 'Espetinho defumado com tempero picante.', 64.00);

-- 7. POPULAR CLIENTES
INSERT INTO cliente (cpf, nome) VALUES
('123.456.789-00', 'João Marcelo'),
('987.654.321-11', 'Joana Marcela');

-- 8. POPULAR FUNCIONÁRIOS
INSERT INTO funcionario (nome, cargo, salario, status) VALUES
('Claudia', 'garçom', 1800.00, 'empregado'),
('Pedro', 'cozinheiro', 2500.00, 'empregado'),
('Marcelo', 'gerente', 5000.00, 'empregado');

-- 9. POPULAR PEDIDOS (Inseri um pedido para você testar se o erro 500 sumiu)
INSERT INTO pedido (id_cliente, id_funcionario, status_pedido) VALUES
(1, 1, 'Em preparo');

-- 10. VERIFICAÇÃO FINAL
SELECT * FROM cardapio;