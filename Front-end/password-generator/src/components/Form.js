import React from 'react';
import { useState } from "react";
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import Item from '@mui/material/Stack';
import { FormGroup } from '@mui/material';
import { Grid } from '@mui/material';
import { InputAdornment } from '@mui/material';
import TextField from '@mui/material/TextField';
import { AccountCircle } from '@mui/icons-material';
import PasswordIcon from '@mui/icons-material/Password';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { Card } from '@mui/material';
import { Typography } from '@mui/material';
import Alert from '@mui/material/Alert';
import AutorenewIcon from '@mui/icons-material/Autorenew';
import LoginIcon from '@mui/icons-material/Login';
import PixIcon from '@mui/icons-material/Pix';
import "./Form.css";

function Form() {

    const [passwordChange, setPasswordChange] = useState({
        initialPassword: "Your Password will be here"
    });

    const [showPassword, setShowPassword] = useState(false);
    
    const [passwordInput, setPasswordInput] = useState();
    const [userIdInput, setUserIdInput] = useState();

    const [showAlert, setShowAlert] = React.useState(false);
    const [showLoginAlert, setShowLoginAlert] = React.useState(false);

    var password;
    var messagePassword = " Wait 30 second for a new generated password!";
    var messageLoginFailed = "Your Login was unsuccesful! Try again";
    var messageLoginSuccessful = "Your Login was succesful!";

    async function generatePassword() {

        try {
            const baseURL = "http://localhost:5232";

            const encodedValue = encodeURIComponent(userIdInput);
            const res = await fetch(`${baseURL}/password?userId=${encodedValue}`, {
                method: "GET",
                datatype: "json"
            });
            console.log(res);

            if (res.status === 204) {
                setShowAlert(true);
                const message = `Wait 30s for a new password, response: ${res.status} - ${res.statusText}`;
                throw new Error(message);
            } else {
                setShowAlert(false);
            }

            const data = await res.json();


            const result = {
                data: data,
                status: res.status,
                statusText: res.statusText,
            };
            console.log(result.statusText);
            password = data['password'];
            console.log(password);

            changeInitialPassword();


        }
        catch (err) {
            console.log(err);
        }
    }

    async function login() {
        try {
            const baseURL = "http://localhost:5232";

            const res = await fetch(`${baseURL}/login`, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "post",
                body: JSON.stringify({
                    "UserId": userIdInput,
                    "Password": passwordInput
                })
            });

            const data = await res.json();

            console.log(data);

            if (data == true) {
                setShowLoginAlert(true);
                const message = `Login successful, response: ${res.status} - ${res.statusText}`;
                console.log(message);
            }
            else {
                setShowLoginAlert(false);
                const message = `Login failed, response: ${res.status} - ${res.statusText}`;
                console.log(message);
            }
        }
        catch (err) {
            console.log(err);
        }
    }
    //   useEffect(() => {
    //     fetch(`/password`)
    //      .then((response) => console.log(response));
    //    }, []);

    //show generated password 


    function changeInitialPassword() {
        setPasswordChange({
            ...passwordChange,
            initialPassword: password
        });
    }


    function onReset() {
        setPasswordInput("");
        setUserIdInput("");
    }


    return (
        <FormGroup id="page" >
            <Grid id="form">
                <Stack spacing={2}>
                    <Item>My password generator</Item>
                    <Item>
                        <div>
                            <AccountCircle className='form-icon' fontSize='large' />
                            <TextField id="user-id" value={userIdInput} onChange={event => setUserIdInput(event.target.value)}
                                label="User id" variant="outlined"
                                helperText="Enter your id to generate a one time password">
                            </TextField>
                        </div>
                        <div>
                            <Button onClick={generatePassword}>Generate password<PixIcon /></Button>
                        </div>
                        <Item>
                            <div>
                                <PasswordIcon className='form-icon' fontSize='large' />
                                <TextField id="password" type={showPassword ? "text" : "password"}
                                    value={passwordInput} onChange={event => setPasswordInput(event.target.value)} label="Password" variant="outlined"
                                    helperText="Notice that: Password expiers in 30 sec."
                                    InputProps={{
                                        endAdornment: <InputAdornment position="end">
                                            <IconButton onClick={() => setShowPassword(s => !s)} style={{ color: "#a742f5" }} >
                                                <VisibilityIcon />
                                            </IconButton >
                                        </InputAdornment>,
                                    }}>
                                </TextField>
                            </div>
                            <div>{showLoginAlert ? <Alert severity="success">
                                {messageLoginSuccessful}</Alert>
                                : <Alert severity="error">{messageLoginFailed} </Alert>}
                                <Button onClick={login}>Login <LoginIcon /></Button>
                                <Button onClick={onReset}>Reset <AutorenewIcon /></Button>
                            </div>
                        </Item>
                        <Item id="card">
                            <Card>
                                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom> Your one time password is:
                                </Typography>
                                {showAlert ? <Alert severity="error">
                                    {messagePassword}</Alert> : null}
                                <Typography variant="h5" component="div" >
                                    {passwordChange.initialPassword}
                                </Typography>
                                <Typography sx={{ mb: 1.5 }} color="text.secondary">Hurry! It expiers in 30 seconds!
                                </Typography>
                            </Card>
                        </Item>
                    </Item>
                </Stack>
            </Grid>
        </FormGroup>
    );
}

export default Form;