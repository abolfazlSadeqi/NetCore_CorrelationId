# Step by step implementation of correlation Id and registration of correlation Id in net core logs 

## Definition
A Correlation ID is a unique number that helps track a single request through different services in an app.
 It makes it easier to follow the request's path, which helps with debugging and monitoring.

## The implementation steps are as follows, which are explained in the post

To implement this, we need to generate the code(Correlation ID) with CorrelationIdService and inject it as a scope. 
This code should be placed in the request header, and we need to create middleware that puts this code(Correlation ID) in the header and logs it as a parameter

1.Install packages Serilog.Extensions.Logging.File in nuget

2.add config  Serilog in appsetting with set CorrelationId

3.implementation Service for generation CorrelationId

4.inject service(ICorrelationIdService) in Startup

5.implement  CorrelationIdMiddleware

    5-1,Add CorrelationId in Header in Invoke

    5-2:add CorrelationId in Response Header in Invoke

    5-3:add CorrelationId in parameter logger 

6.add   CorrelationIdMiddleware

7.add config to appsetting in program file


