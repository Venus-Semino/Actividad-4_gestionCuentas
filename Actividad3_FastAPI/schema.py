import typing
import strawberry
from uuid import UUID
from datetime import datetime
from database import SessionLocal, Account, Concept, AccountTypeEnum, ConceptTypeEnum

# Registrar los Enums en Strawberry
AccountType = strawberry.enum(AccountTypeEnum)
ConceptType = strawberry.enum(ConceptTypeEnum)

@strawberry.type
class AccountNode:
    id: UUID
    company_id: UUID
    account_type: AccountType
    name: str
    bank_name: typing.Optional[str]
    is_active: bool

@strawberry.type
class ConceptNode:
    id: UUID
    company_id: UUID
    concept_type: ConceptType
    name: str
    is_active: bool

@strawberry.input
class CreateAccountInput:
    company_id: UUID
    account_type: AccountType
    name: str
    bank_name: typing.Optional[str] = None

@strawberry.input
class CreateConceptInput:
    company_id: UUID
    concept_type: ConceptType
    name: str

@strawberry.type
class Query:
    @strawberry.field
    def accounts(self, company_id: UUID, account_type: typing.Optional[AccountType] = None, active_only: typing.Optional[bool] = None) -> typing.List[AccountNode]:
        with SessionLocal() as db:
            query = db.query(Account).filter(Account.company_id == company_id)
            if account_type:
                query = query.filter(Account.account_type == account_type.value)
            if active_only:
                query = query.filter(Account.is_active == True)
            
            return [AccountNode(**account.__dict__) for account in query.all()]

    @strawberry.field
    def concepts(self, company_id: UUID, concept_type: typing.Optional[ConceptType] = None, active_only: typing.Optional[bool] = None) -> typing.List[ConceptNode]:
        with SessionLocal() as db:
            query = db.query(Concept).filter(Concept.company_id == company_id)
            if concept_type:
                query = query.filter(Concept.concept_type == concept_type.value)
            if active_only:
                query = query.filter(Concept.is_active == True)
                
            return [ConceptNode(**concept.__dict__) for concept in query.all()]

@strawberry.type
class Mutation:
    @strawberry.mutation
    def create_account(self, input: CreateAccountInput) -> AccountNode:
        with SessionLocal() as db:
            exists = db.query(Account).filter_by(company_id=input.company_id, name=input.name).first()
            if exists:
                raise Exception("Ya existe una cuenta con este nombre para la empresa.")
            
            new_account = Account(
                company_id=input.company_id,
                account_type=input.account_type.value,
                name=input.name,
                bank_name=input.bank_name
            )
            db.add(new_account)
            db.commit()
            db.refresh(new_account)
            return AccountNode(**new_account.__dict__)

    @strawberry.mutation
    def create_concept(self, input: CreateConceptInput) -> ConceptNode:
        with SessionLocal() as db:
            exists = db.query(Concept).filter_by(company_id=input.company_id, concept_type=input.concept_type.value, name=input.name).first()
            if exists:
                raise Exception("Ya existe este concepto registrado para la empresa.")
            
            new_concept = Concept(
                company_id=input.company_id,
                concept_type=input.concept_type.value,
                name=input.name
            )
            db.add(new_concept)
            db.commit()
            db.refresh(new_concept)
            return ConceptNode(**new_concept.__dict__)

schema = strawberry.Schema(query=Query, mutation=Mutation)