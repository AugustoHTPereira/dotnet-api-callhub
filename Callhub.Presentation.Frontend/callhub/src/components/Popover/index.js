import React, { useState } from "react";
import { IoIosClose } from "react-icons/io";

import "./style.css";

const Popover = ({
  position,
  title,
  message,
  theme,
  ico = null,
  closeButton = true,
  timeout = 0,
}) => {
  const [visible, setVisible] = useState(true);

  if (timeout)
    setTimeout(() => {
      setVisible(false);
    }, timeout);

  if (visible)
    return (
      <div className={`Popover Popover${position} ${theme}`}>
        {ico ? <div className="Ico">{ico}</div> : null}

        <div className="Body">
          {closeButton ? (
            <span onClick={() => setVisible(false)} className="GoOut">
              <IoIosClose size={26} />
            </span>
          ) : null}

          <h2>{title}</h2>

          <p>{message}</p>
        </div>
      </div>
    );
  else return null;
};

export default Popover;
