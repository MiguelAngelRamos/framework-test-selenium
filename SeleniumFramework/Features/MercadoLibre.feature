@MercadoLibre
Feature: Probar la funcionalidad de búsqueda de MercadoLibre

  Scenario Outline: Como cliente, cuando busco un producto, quiero ver si la tercera opción está disponible para comprar y se puede agregar al carrito.

    Given el usuario navega a www.mercadolibre.cl
    When el usuario busca "<Product>"
    And el usuario selecciona el tercer artículo
    Then después de hacer click para agregar el artículo al carrito, se le pide al usuario que inicie sesión o cree una cuenta

  Examples:
    | Product     |
    | PlayStation |