begin transaction
insert into department (deptName)
values ('Marketing')
insert into department (deptName)
values ('Manufacturing')
insert into department (deptName)
values ('Engineering')
insert into department (deptName)
values ('Operations')

insert into project (projName)
values ('American Professional')
insert into project (projName)
values ('Player Series')
insert into project (projName)
values ('Offsets')
insert into project (projName)
values ('Squier')

insert into jobTitle (name)
values ('CEO')
insert into jobTitle (name)
values ('Designer')
insert into jobTitle (name)
values ('Builder')
insert into jobTitle (name)
values ('Marketer')

commit


begin transaction
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='CEO'), 'Fender', 'Leo', 'male', '08/10/1909', '01/01/1946', (select deptNumber from department where deptName='Operations'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Builder'), 'Smith', 'Jim', 'male', '11/11/1970', '01/21/1988', (select deptNumber from department where deptName='Manufacturing'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Designer'), 'Anderson', 'Susan', 'female', '05/14/1968', '01/21/1988', (select deptNumber from department where deptName='Engineering'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Marketer'), 'Simpson', 'Lisa', 'female', '08/21/1982', '06/01/2008', (select deptNumber from department where deptName='Marketing'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Builder'), 'Adams', 'John', 'male', '09/16/1990', '02/22/2018', (select deptNumber from department where deptName='Manufacturing'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Builder'), 'Ant', 'Adam', 'male', '09/16/1978', '03/12/2006', (select deptNumber from department where deptName='Manufacturing'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Marketer'), 'Sanders', 'Kelly', 'female', '08/17/1969', '06/13/1996', (select deptNumber from department where deptName='Marketing'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Designer'), 'Lopez', 'Carlos', 'male', '10/10/1976', '06/20/1998', (select deptNumber from department where deptName='Engineering'))
insert into employee (jobTitleId, lastName, firstName, gender, dateOfBirth, dateOfHire, deptNumber)
values ((select jobTitleId from jobTitle where jobTitle.name='Builder'), 'Fey', 'Tina', 'male', '10/10/1981', '12/01/2002', (select deptNumber from department where deptName='Manufacturing'))
commit


begin transaction
insert into project_employee (projNumber, employeeId)
values ((select projNumber from project where projName='American Professional'), (select employeeId from employee where employee.lastName='Simpson' and employee.firstName='Lisa'))
insert into project_employee (projNumber, employeeId)
values ((select projNumber from project where projName='Player Series'), (select employeeId from employee where employee.lastName='Smith' and employee.firstName='Jim'))
insert into project_employee (projNumber, employeeId)
values ((select projNumber from project where projName='Offsets'), (select employeeId from employee where employee.lastName='Sanders' and employee.firstName='Kelly'))
insert into project_employee (projNumber, employeeId)
values ((select projNumber from project where projName='Squier'), (select employeeId from employee where employee.lastName='Lopez' and employee.firstName='Carlos'))
commit