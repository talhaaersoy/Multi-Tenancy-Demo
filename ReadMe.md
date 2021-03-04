# Multi Tenant Architecture Demo

While setting up the multi tenant structure, I used servers and databases as much as the tenant I used.

## Tenant Architecture

##### 1.TenantCatalog.cs

This class reads the tenants specified in our configuration file and turns them into an AppTenant object.

##### 2. TenantResolver

This class resolves the data read in the Catalog object to define to AnnalContext.

## Utilities

### 1. Autofac

I used this tool to migrate dependency solving works from web API to business layer and to run Validation rules as an aspect.

##### 2. Jwt

I got help from the hmac algorithm while creating the password.

##### 3.Fluent Validation

##### 























