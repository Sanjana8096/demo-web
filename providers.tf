terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.70.0"
    }
  }
}

provider "azurerm" {
  features {}
  subscription_id = "4e318d48-5741-48bb-a817-99d65dc7227f"
  client_id       = "f094426d-02e7-42a9-a70d-60891f0b5d98"
  client_secret   = "4_U8Q~QUWGHfKNt0OAwxif0Dqjy9SUsoR9i--cv2"
  tenant_id       = "30bf9f37-d550-4878-9494-1041656caf27"
}
