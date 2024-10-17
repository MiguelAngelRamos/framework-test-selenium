@Form
Feature: Validar Formulario de Ingreso

  Scenario: Verificar el mensaje de error por formato inválido de correo electrónico
    Given el usuario navega al formulario
    When el usuario ingresa "Sofia" en el campo de texto
    And el usuario ingresa "usuario@dominio" en el campo de correo electrónico
    And el usuario ingresa "secretoabsoluto" en el campo de contraseña
    And el usuario selecciona "opcion1" del desplegable
    And el usuario selecciona el radio button
    And el usuario marca el checkbox
    And el usuario envía el formulario
    Then el mensaje de error de correo inválido debe aparecer