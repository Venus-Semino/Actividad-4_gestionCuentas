from fastapi import FastAPI
from strawberry.fastapi import GraphQLRouter
from database import engine, Base, SessionLocal, Account, Concept, AccountTypeEnum, ConceptTypeEnum
from schema import schema
import uuid

# Asegurar que las tablas existan
Base.metadata.create_all(bind=engine)

app = FastAPI(title="Sistema Financiero API")

# Router de GraphQL
graphql_app = GraphQLRouter(schema)
app.include_router(graphql_app, prefix="/graphql")

# Insertar datos semilla (Seeding) al arrancar
@app.on_event("startup")
def seed_data():
    with SessionLocal() as db:
        if db.query(Account).count() == 0:
            company_id = uuid.UUID("11111111-1111-1111-1111-111111111111")
            
            # Cuentas
            db.add_all([
                Account(company_id=company_id, account_type=AccountTypeEnum.CASH, name="Caja Chica"),
                Account(company_id=company_id, account_type=AccountTypeEnum.DEBIT, name="Cuenta Operativa", bank_name="Banamex"),
                Account(company_id=company_id, account_type=AccountTypeEnum.INVESTMENT, name="Fondo de Inversión")
            ])
            
            # Conceptos (Ingresos)
            db.add_all([
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.INCOME, name="Venta de servicios"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.INCOME, name="Rendimientos"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.INCOME, name="Aportación de capital"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.INCOME, name="Venta de activos"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.INCOME, name="Reembolsos"),
            ])
            
            # Conceptos (Egresos)
            db.add_all([
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.EXPENSE, name="Pago de nómina"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.EXPENSE, name="Renta de oficina"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.EXPENSE, name="Servicios públicos"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.EXPENSE, name="Compra de equipo"),
                Concept(company_id=company_id, concept_type=ConceptTypeEnum.EXPENSE, name="Licencias de software"),
            ])
            db.commit()