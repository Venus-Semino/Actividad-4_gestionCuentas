import os
import enum
import uuid
from datetime import datetime, timezone
from sqlalchemy import create_engine, Column, String, Boolean, DateTime, Enum, UniqueConstraint
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import declarative_base, sessionmaker

DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://postgres:tu_password@localhost:5432/sistema_financiero")

engine = create_engine(DATABASE_URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()

class AccountTypeEnum(enum.Enum):
    DEBIT = "DEBIT"
    CREDIT = "CREDIT"
    CASH = "CASH"
    SAVINGS = "SAVINGS"
    INVESTMENT = "INVESTMENT"
    WALLET = "WALLET"
    OTHER = "OTHER"

class ConceptTypeEnum(enum.Enum):
    INCOME = "INCOME"
    EXPENSE = "EXPENSE"

class Account(Base):
    __tablename__ = "accounts"
    __table_args__ = (UniqueConstraint('company_id', 'name', name='uq_account_company_name'),)

    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    company_id = Column(UUID(as_uuid=True), nullable=False)
    account_type = Column(Enum(AccountTypeEnum), nullable=False)
    name = Column(String, nullable=False)
    bank_name = Column(String, nullable=True)
    account_number = Column(String, nullable=True)
    clabe = Column(String, nullable=True)
    card_last_digits = Column(String, nullable=True)
    short_description = Column(String, nullable=True)
    long_description = Column(String, nullable=True)
    is_active = Column(Boolean, default=True)
    created_at = Column(DateTime, default=lambda: datetime.now(timezone.utc))
    updated_at = Column(DateTime, default=lambda: datetime.now(timezone.utc))

class Concept(Base):
    __tablename__ = "concepts"
    __table_args__ = (UniqueConstraint('company_id', 'concept_type', 'name', name='uq_concept_company_type_name'),)

    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    company_id = Column(UUID(as_uuid=True), nullable=False)
    concept_type = Column(Enum(ConceptTypeEnum), nullable=False)
    name = Column(String, nullable=False)
    short_description = Column(String, nullable=True)
    long_description = Column(String, nullable=True)
    is_active = Column(Boolean, default=True)
    created_at = Column(DateTime, default=lambda: datetime.now(timezone.utc))
    updated_at = Column(DateTime, default=lambda: datetime.now(timezone.utc))