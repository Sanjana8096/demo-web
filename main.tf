locals {
  app_lower = lower(var.app)
  env_lower     = lower(var.env)
}

resource "azurerm_resource_group" "rg" {
  name     = format("%s-%s-rg", local.app_lower, local.env_lower)
  location = var.location
  tags     = var.tags
}

resource "azurerm_app_service_plan" "plan" {
  name                = format("%s-%s-plan", local.app_lower, local.env_lower)
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "app" {
  name                = format("%s-%s-app", local.app_lower, local.env_lower)
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.plan.id
  tags                = var.tags
  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.appi.instrumentation_key
  }
}

resource "azurerm_app_service_slot" "stage" {
  name                = format("%s-%s-stage", local.app_lower, local.env_lower)
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_name    = azurerm_app_service.app.name
  app_service_plan_id = azurerm_app_service_plan.plan.id
}

resource "azurerm_log_analytics_workspace" "logs" {
  name                = format("%s-%s-logs", local.app_lower, local.env_lower)
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku                 = "PerGB2018"
  retention_in_days  = 30
  tags                = var.tags
}

resource "azurerm_application_insights" "appi" {
  name                = format("%s-%s-appi", local.app_lower, local.env_lower)
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"
  tags                = var.tags
  workspace_id        = azurerm_log_analytics_workspace.logs.id
}

output "instrumentation_key" {
  value     = azurerm_application_insights.appi.instrumentation_key
  sensitive = true
}

output "app_id" {
  value     = azurerm_application_insights.appi.app_id
  sensitive = true
}